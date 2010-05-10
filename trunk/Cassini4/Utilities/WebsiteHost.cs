/* **********************************************************************************
 *
 * Copyright (c) Tanzim Saqib. All rights reserved.
 *
 * This source code is subject to terms and conditions of the Microsoft Public
 * License (Ms-PL). A copy of the license can be found in the license.htm file
 * included in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * For continued development:   http://www.TanzimSaqib.com
 * Source:                      http://cassini.googlecode.com/
 * License information:         http://www.opensource.org/licenses/ms-pl.html
 *
 * **********************************************************************************/

namespace Cassini
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Runtime.Remoting;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Hosting;

    public class WebsiteHost : MarshalByRefObject
    {
        private Host _Host;
        public Website Website { get; set; }
        private Socket _Socket { get; set; }
        private bool _IsShutdownInProgress = false;

        public WebsiteHost(Website website)
        {
            Website = website;
        }

        // called at the end of request processing
        // to disconnect the remoting proxy for Connection object
        // and allow GC to pick it up
        public void OnRequestEnd(Connection conn)
        {
            RemotingServices.Disconnect(conn);
        }

        public void Stopped()
        {
            _Host = null;
        }

        private static Socket CreateSocketBindAndListen(AddressFamily family, IPAddress address, int port)
        {
            var socket = new Socket(family, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(address, port));
            socket.Listen((int)SocketOptionName.MaxConnections);
            return socket;
        }

        private Host GetHost()
        {
            if (_IsShutdownInProgress)
                return null;

            var host = _Host;

            if (host == null)
            {
                lock (this)
                {
                    host = _Host;
                    if (host == null)
                    {
                        host = (Host)CreateWorkerAppDomainWithHost(Website.VirtualRoot, Website.PhysicalPath, typeof(Host));
                        host.Configure(this, Website.Port, Website.VirtualRoot, Website.PhysicalPath);
                        _Host = host;
                    }
                }
            }

            return host;
        }

        private static object CreateWorkerAppDomainWithHost(string virtualPath, string physicalPath, Type hostType)
        {
            // this creates worker app domain in a way that host doesn't need to be in GAC or bin
            // using BuildManagerHost via private reflection
            var uniqueAppString = string.Concat(virtualPath, physicalPath).ToLowerInvariant();
            var appId = uniqueAppString.GetHashCode().ToString("x", CultureInfo.InvariantCulture);

            // create BuildManagerHost in the worker app domain
            var appManager = ApplicationManager.GetApplicationManager();
            var buildManagerHostType = typeof(HttpRuntime).Assembly.GetType("System.Web.Compilation.BuildManagerHost");
            var buildManagerHost = appManager.CreateObject(appId, buildManagerHostType, virtualPath, physicalPath, false);

            // call BuildManagerHost.RegisterAssembly to make Host type loadable in the worker app domain
            buildManagerHostType.InvokeMember(
                "RegisterAssembly",
                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic,
                null,
                buildManagerHost,
                new object[2] { hostType.Assembly.FullName, hostType.Assembly.Location });

            // create Host in the worker app domain
            return appManager.CreateObject(appId, hostType, virtualPath, physicalPath, false);
        }

        public bool IsPortUsable()
        {
            var usable = false;

            try
            {
                _Socket = CreateSocketBindAndListen(AddressFamily.InterNetwork, IPAddress.Loopback, Website.Port);
                _Socket.Close();
                usable = true;
            }
            catch
            {
                try
                {
                    _Socket = CreateSocketBindAndListen(AddressFamily.InterNetworkV6, IPAddress.IPv6Loopback, Website.Port);
                    _Socket.Close();
                    usable = true;
                }
                catch 
                {
                }
            }

            return usable;
        }

        public void Start()
        {
            _IsShutdownInProgress = false;

            try
            {
                _Socket = CreateSocketBindAndListen(AddressFamily.InterNetwork, IPAddress.Loopback, Website.Port);
            }
            catch(Exception e)
            {
                _Socket = CreateSocketBindAndListen(AddressFamily.InterNetworkV6, IPAddress.IPv6Loopback, Website.Port);
            }

            Task.Factory.StartNew(() =>
                                      {
                                          while (!_IsShutdownInProgress)
                                          {
                                              try
                                              {
                                                  var acceptedSocket = _Socket.Accept();

                                                  Task.Factory.StartNew(() =>
                                                                            {
                                                                                if (!_IsShutdownInProgress)
                                                                                {
                                                                                    var conn = new Connection(this, acceptedSocket);

                                                                                    // wait for at least some input
                                                                                    if (conn.WaitForRequestBytes() == 0)
                                                                                    {
                                                                                        conn.WriteErrorAndClose(400);
                                                                                        return;
                                                                                    }

                                                                                    // find or create host
                                                                                    var host = GetHost();
                                                                                    if (host == null)
                                                                                    {
                                                                                        conn.WriteErrorAndClose(500);
                                                                                        return;
                                                                                    }

                                                                                    // process request in worker app domain
                                                                                    host.ProcessRequest(conn);
                                                                                }
                                                                            });
                                              }
                                              catch
                                              {
                                                  Thread.Sleep(100);
                                              }
                                          }
                                      });
        }

        public void Stop()
        {
            _IsShutdownInProgress = true;

            if(_Socket != null)
                _Socket.Close();
        }
    }
}

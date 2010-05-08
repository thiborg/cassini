/* **********************************************************************************
 *
 * Copyright (c) Tanzim Saqib. URL: http://www.TanzimSaqib.com. All rights reserved.
 *
 * This source code is subject to terms and conditions of the Microsoft Public
 * License (Ms-PL). A copy of the license can be found in the license.htm file
 * included in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * **********************************************************************************/

namespace Cassini
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Configuration;

    public class App
    {
        private static readonly App _App = new App();
        public const string APP_NAME = "Cassini 4.0";

        private App()
        {
        }

        public static CassiniConfig Config = null;
        public static Dictionary<string, WebsiteHost> WebSiteHosts = new Dictionary<string, WebsiteHost>();

        public static void SubscribeEvent(string key, Action<dynamic, dynamic> action)
        {
            EventBroker.Subscribe(key, action);
        }

        public static void RaiseEvent(string key, object sender, EventBrokerEventArgs args)
        {
            EventBroker.Raise(key, sender, args);
        }

        public void Dispose()
        {

        }

        public static void Startup()
        {
            RefreshConfig();

            foreach(var website in App.Config.Websites)
            {
                App.WebSiteHosts.Add(website.Value.Url, website.Value.ToWebsiteHost());
            }

            foreach(var host in App.WebSiteHosts)
            {
                if(host.Value.Website.IsRunning && App.Config.IsRunning)
                    host.Value.Start();
            }

            //Config.Websites.Add("polapan", new CassiniWebsiteConfig { VirtualRoot = "vir", Url = "Url" });
            //Config.Websites.Add("polapan2", new CassiniWebsiteConfig { VirtualRoot = "vir", Url = "Url2" });
            //SaveConfig();
        }

        public static void SaveConfig()
        {
            if (Config == null)
            {
                Config = new CassiniConfig();
            }

            CassiniXmlSerializer.Serialize<CassiniConfig>(Config, CassiniConfigConstants.XML_FILE_NAME);
        }

        public static void RefreshConfig()
        {
            if (File.Exists(CassiniConfigConstants.XML_FILE_NAME))
            {
                Config = CassiniXmlSerializer.Deserialize<CassiniConfig>(CassiniConfigConstants.XML_FILE_NAME) ?? new CassiniConfig();
            }
            else
            {
                SaveConfig();
            }
        }
    }
}

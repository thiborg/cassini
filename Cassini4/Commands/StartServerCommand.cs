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

namespace Cassini.Commands
{
    using System.Collections.Generic;

    public class StartServerCommand : CommandBase
    {
        public StartServerCommand()
        {
            Tasks = new Queue<CassiniTask>();

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Starting server..",
                    Argument = null,
                    Work = (arg) =>
                    {
                        foreach(var host in App.WebSiteHosts)
                        {
                            if(host.Value.Website.IsRunning)
                                host.Value.Start();
                        }

                        return CassiniTaskResult.NoResult;
                    }
                });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Saving configuration..",
                    Argument = null,
                    Work = (arg) =>
                    {
                        App.Config.IsRunning = true;
                        App.SaveConfig();

                        return CassiniTaskResult.NoResult;
                    }
                });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Resetting counter..",
                    Argument = null,
                    Work = (arg) =>
                    {
                        App.RaiseEvent(EventKeys.SERVER_STARTED, this, new EventBrokerEventArgs(null));
                        return CassiniTaskResult.NoResult;
                    }
                });
        }

        public override void Execute()
        {
            Execute(Tasks);
        }
    }
}

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

namespace Cassini.Commands
{
    using System.Collections.Generic;

    public class StopServerCommand : CommandBase
    {
        public StopServerCommand()
        {
            Tasks = new Queue<CassiniTask>();

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Stopping websites..",
                    Argument = null,
                    Work = (arg) =>
                    {
                        foreach(var host in App.WebSiteHosts)
                        {
                            host.Value.Stop();
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
                        App.Config.IsRunning = false;
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
                        App.RaiseEvent(EventKeys.SERVER_STOPPED, this, new EventBrokerEventArgs(null));
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

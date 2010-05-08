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

    public class StartSiteCommand : CommandBase
    {
        public StartSiteCommand(Website website)
        {
            Tasks = new Queue<CassiniTask>();

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Starting website..",
                    Argument = website,
                    Work = (arg) =>
                    {
                        if(App.WebSiteHosts.ContainsKey(website.Url))
                        {
                            App.WebSiteHosts[website.Url].Start();
                        }

                        return CassiniTaskResult.NoResult;
                    }
                });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Writing to configuration file..",
                    Argument = website,
                    Work = (arg) =>
                    {
                        App.Config.Websites[website.Url].IsRunning = true;
                        App.SaveConfig();

                        return CassiniTaskResult.NoResult;
                    }
                });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Reflecting changes..",
                    Argument = website,
                    Work = (arg) =>
                    {
                        App.RaiseEvent(EventKeys.WEBSITE_CHANGED, this, new EventBrokerEventArgs(website));
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

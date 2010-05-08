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

    public class DeleteSiteCommand : CommandBase
    {
        public DeleteSiteCommand(Website website)
        {
            Tasks = new Queue<CassiniTask>();

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Stopping website..",
                    Argument = null,
                    Work = (arg) =>
                    {
                        if(App.WebSiteHosts.ContainsKey(website.Url))
                        {
                            App.WebSiteHosts[website.Url].Stop();
                            App.WebSiteHosts.Remove(website.Url);
                        }

                        return CassiniTaskResult.NoResult;
                    }
                });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Deleting website..",
                    Argument = null,
                    Work = (arg) =>
                    {
                        App.RaiseEvent(EventKeys.WEBSITE_DELETED, this, new EventBrokerEventArgs(website));

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
                        if (App.Config.Websites.ContainsKey(website.Url))
                        {
                            App.Config.Websites.Remove(website.Url);
                            App.SaveConfig();
                        }

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

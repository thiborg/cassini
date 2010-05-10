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

    public class HostSiteCommand : CommandBase
    {
        public HostSiteCommand(Website website)
        {
            Tasks = new Queue<CassiniTask>();

            Tasks.Enqueue(
                new CassiniTask
                    {
                        Text = "Validating input..",
                        Argument = website,
                        Work = (arg) =>
                                   {
                                       if (!new WebsiteHost(website).IsPortUsable())
                                       {
                                           Cancel(new PortInUseException());
                                       }

                                       if(App.WebSiteHosts.ContainsKey(website.Url))
                                       {
                                           Cancel(new WebsiteExistsAtTheSameUrl());
                                       }

                                       return CassiniTaskResult.NoResult;
                                   }
                    });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Creating website..",
                    Argument = website,
                    Work = (arg) =>
                    {
                        var host = new WebsiteHost(website);

                        if(website.IsRunning)
                            host.Start();

                        App.WebSiteHosts.Add(website.Url, host);

                        return CassiniTaskResult.NoResult;
                    }
                });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Setting up website..",
                    Argument = website,
                    Work = (arg) =>
                    {
                        App.RaiseEvent(EventKeys.WEBSITE_CREATED, this, new EventBrokerEventArgs(website));

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
                        if(!App.Config.Websites.ContainsKey(website.Url))
                        {
                            App.Config.Websites.Add(website.Url, website.ToConfiguration());
                        }
                        else
                        {
                            App.Config.Websites[website.Url] = website.ToConfiguration();
                        }

                        App.SaveConfig();

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

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

    public class ChangeSiteCommand : CommandBase
    {
        public ChangeSiteCommand(Website old, Website website)
        {
            Tasks = new Queue<CassiniTask>();

            Tasks.Enqueue(
                new CassiniTask
                    {
                        Text = "Validating input..",
                        Argument = website,
                        Work = (arg) =>
                                   {
                                       if(website.Port != old.Port && !new WebsiteHost(website).IsPortUsable())
                                       {
                                           Cancel(new PortInUseException());
                                       }

                                       if (old.Url != website.Url && App.WebSiteHosts.ContainsKey(website.Url))
                                       {
                                           Cancel(new WebsiteExistsAtTheSameUrl());
                                       }

                                       return CassiniTaskResult.NoResult;
                                   }
                    });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Stopping website..",
                    Argument = website,
                    Work = (arg) =>
                    {
                        CommandExecutor.Execute(new DeleteSiteCommand(old));

                        return CassiniTaskResult.NoResult;
                    }
                });

            Tasks.Enqueue(
                new CassiniTask
                {
                    Text = "Confuguring website..",
                    Argument = website,
                    Work = (arg) =>
                    {
                        CommandExecutor.Execute(new HostSiteCommand(website));
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

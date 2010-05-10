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
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CommandExecutor
    {
        public static void Execute(ICommand command, Action<ArrayList> successHandler, Action<List<Exception>> failHandler)
        {
            var result = Execute(command);

            if(result.Success)
            {
                if (successHandler != null)
                    successHandler(result.Results);                
            }
            else
            {
                if(failHandler != null)
                    failHandler(result.Exceptions);
            }
        }

        public static CassiniTaskResult Execute(ICommand command)
        {
            var task = Task.Factory.StartNew(() => command.Execute());

            try
            {
                task.Wait();
            }
            catch (AggregateException aggregateException)
            {
                command.SetException(aggregateException.GetBaseException());
            }

            return command.GetResult();
        }
    }
}

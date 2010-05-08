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

using System;
using System.Collections.Generic;

namespace Cassini
{
    public abstract class CommandBase : ICommand
    {
        public CassiniTaskResult Result { get; set; }

        protected CommandStatus Status { get; set; }
        protected int StepsCompleted { get; set; }
        protected int TotalSteps { get; set; }
        protected string ProgressText { get; set; }
        protected Queue<CassiniTask> Tasks = new Queue<CassiniTask>();

        public CommandBase()
        {
            Status = CommandStatus.Idle;
            StepsCompleted = 0;
            Result = new CassiniTaskResult();
        }

        /*
        public virtual dynamic ExecuteParallel(Queue<CassiniTask> tasks)
        {
            Tasks = tasks;
            TotalSteps = Tasks.Count;

            Status = CommandStatus.Running;

            Parallel.For(0, TotalSteps, (i, loopStep) =>
                                            {
                                                var task = tasks.Dequeue();
                                                ProgressText = task.Text;

                                                StepsCompleted = i;
                                                task.Work(task.Argument);
                                            });
            
            Status = CommandStatus.Completed;
        }*/

        public virtual void Execute(Queue<CassiniTask> tasks)
        {
            Tasks = tasks;
            TotalSteps = Tasks.Count;

            Status = CommandStatus.Running;

            for(var i = 0; i < TotalSteps; ++i)
            {
                if (GetStatus() != CommandStatus.Cancelled)
                {
                    var task = tasks.Dequeue();
                    ProgressText = task.Text;
                    StepsCompleted = i;

                    var result = task.Work(task.Argument);

                    if(result != CassiniTaskResult.NoResult)
                        Result.Results.Add(result);
                }
            }

            Status = CommandStatus.Completed;

            if(Result.Exceptions.Count == 0)
                Result.Success = true;
        }

        public virtual void Execute()
        {
            // Placeholder
        }

        public virtual void Cancel()
        {
            Status = CommandStatus.Cancelled;
        }

        public virtual void Cancel(Exception e)
        {
            SetException(e);
            Cancel();
        }

        public virtual CommandStatus GetStatus()
        {
            return Status;
        }

        public virtual int GetProgressStep()
        {
            return StepsCompleted;
        }

        public virtual int GetTotalProgressSteps()
        {
            return TotalSteps;
        }

        public virtual string GetProgressText()
        {
            return ProgressText;
        }

        public virtual void SetException(Exception e)
        {
            Result.Exceptions.Add(e);
        }

        public virtual void SetResult(dynamic result)
        {
            Result.Results.Add(result);
        }

        public virtual CassiniTaskResult GetResult()
        {
            return Result;
        }

    }
}

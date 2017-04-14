using System;
using System.ComponentModel;
using Hangfire.Server;
using Scheduled.TaskCenter.Core;

namespace Scheduled.TaskCenter.Server.RecurrentTask
{
    public class Job3 : IRecurringTask
    {

        public string JobId => "uoko-job3";
        public string CronExpression => "* * * * *";
        [DisplayName("任务3")]
        public void Excute(PerformContext context)
        {
            Console.WriteLine("uoko-job3");
            throw new Exception("AAAAAAAAAAAA");
        }
    }
}

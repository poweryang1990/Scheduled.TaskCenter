using System;
using System.ComponentModel;
using Hangfire.Console;
using Hangfire.Server;

namespace Scheduled.TaskCenter.Core.RecurrentTask
{
    public class Job1 : IRecurringTask
    {
       
        public string JobId => "uoko-job1";
        public string CronExpression => "* * * * *";
        [DisplayName("任务1")]
        public void Excute(PerformContext context)
        {
            context.WriteLine("开始执行任务1......");
            Console.WriteLine("uoko-job1");
        }
    }
}

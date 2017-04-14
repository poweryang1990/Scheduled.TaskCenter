using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Console;
using Hangfire.Server;
using Scheduled.TaskCenter.Core;

namespace Scheduled.TaskCenter.Server.RecurrentTask
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

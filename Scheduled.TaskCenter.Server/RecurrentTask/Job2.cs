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
    public class Job2 : IRecurringTask
    {

        public string JobId => "uoko-job2";
        public string CronExpression => "* * * * *";
        [DisplayName("任务2")]
        public void Excute(PerformContext context)
        {
            context.SetTextColor(ConsoleTextColor.Red);
            context.WriteLine("处理XXX账单 出现异常......");
            context.ResetTextColor();
            Console.WriteLine("uoko-job2");
        }
    }
}

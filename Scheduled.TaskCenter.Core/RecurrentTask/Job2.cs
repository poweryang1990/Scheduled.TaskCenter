using System;
using System.ComponentModel;
using Hangfire.Console;
using Hangfire.Server;

namespace Scheduled.TaskCenter.Core.RecurrentTask
{
    public class Job2 : IRecurringTask
    {

        public string JobId => "uoko-job2";
        public string CronExpression => "* * * * *";
        [DisplayName("任务2")]
        public void Excute(PerformContext context)
        {
            context.WarningWriteLine("处理XXX账单 出现异常......");
            Console.WriteLine($"uoko-job2  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}

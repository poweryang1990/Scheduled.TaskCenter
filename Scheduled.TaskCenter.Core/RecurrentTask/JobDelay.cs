using System;
using System.ComponentModel;
using Hangfire;
using Hangfire.Server;

namespace Scheduled.TaskCenter.Core.RecurrentTask
{
    public class JobDelay 
    {

        public string JobId => "uoko-JobDelay";
        public string CronExpression => "* * * * *";
        [DisplayName("利用 递归方式 处理 频率 低于1分钟的重复任务")]
        public static void Excute(PerformContext context)
        {
           
           Console.WriteLine($"uoko-JobDelay {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
           BackgroundJob.Schedule(() => Excute(context), TimeSpan.FromSeconds(5));
        }
    }
}

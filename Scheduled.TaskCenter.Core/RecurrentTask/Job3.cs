using System;
using System.ComponentModel;
using Hangfire.Server;

namespace Scheduled.TaskCenter.Core.RecurrentTask
{
    public class Job3 : IRecurringTask
    {

        public string JobId => "uoko-job3";
        public string CronExpression => "* * * * *";
        [DisplayName("任务3")]
        public void Excute(PerformContext context)
        {
            try
            {
                Console.WriteLine($"uoko-job3  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                throw new Exception("AAAAAAAAAAAA");
            }
            catch (Exception ex)
            {
                context.ErrorWriteLine(ex.ToString());
            }
        }
    }
}

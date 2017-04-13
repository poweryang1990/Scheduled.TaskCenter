using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Scheduled.TaskCenter.Core;

namespace Scheduled.TaskCenter.Server.RecurrentTask
{
    public class Job1 : IRecurringTask
    {
       
        public string JobId => "uoko-job1";
        public string CronExpression => "* * * * *";
        [Queue("uoko_recurrent_task")]
        public void Excute()
        {
            Console.WriteLine("uoko-job1");
        }
    }
}

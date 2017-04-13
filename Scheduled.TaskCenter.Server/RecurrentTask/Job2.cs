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
    public class Job2 : IRecurringTask
    {

        public string JobId => "uoko-job2";
        public string CronExpression => "* * * * *";
        public void Excute()
        {
            Console.WriteLine("uoko-job2");
        }
    }
}

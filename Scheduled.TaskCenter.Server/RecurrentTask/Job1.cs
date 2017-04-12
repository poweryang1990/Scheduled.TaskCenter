using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Scheduled.TaskCenter.Core;

namespace Scheduled.TaskCenter.Server.RecurrentTask
{
    public class Job1 : RecurringTaskBase
    {
       

        public override string GetRecurringJobId()
        {
            return "uoko-job1";
        }

        public override string GetCronExpression()
        {
            return "* * * * *";
        }

        public override Expression<Action> GetAction()
        {
            return () => Console.WriteLine("uoko-job1");
        }
    }
}

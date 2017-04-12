using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace Scheduled.TaskCenter.Core
{
    /// <summary>
    /// 周期性任务
    /// </summary>
    public abstract class RecurringTaskBase
    {
        private string cronstr=> GetCronExpression();
        private Expression<Action> myacotion => GetAction();
        private string jobId => GetRecurringJobId();
        /// <summary>
        /// 周期性任务 唯一ID
        /// </summary>
        /// <returns></returns>
        public abstract string GetRecurringJobId();
        /// <summary>
        /// 周期性执行 Cron表达式
        /// </summary>
        /// <returns></returns>
        public abstract string GetCronExpression();

        /// <summary>
        /// 任务执行的内容
        /// </summary>
        /// <returns></returns>
        public abstract Expression<Action> GetAction();

        public void AddTask()
        {
            RecurringJob.AddOrUpdate(jobId, myacotion, cronstr,queue:"uoko_recurrent_task");
        }
    }
}

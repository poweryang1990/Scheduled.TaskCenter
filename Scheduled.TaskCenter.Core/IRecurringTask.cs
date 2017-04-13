using Hangfire;

namespace Scheduled.TaskCenter.Core
{
    /// <summary>
    /// 周期性任务契约
    /// </summary>
    public interface IRecurringTask
    {
        /// <summary>
        /// Cron 表达式
        /// </summary>
        string CronExpression { get;  }
        /// <summary>
        /// 唯一的JobId
        /// </summary>
        string JobId { get;  }
        [AutomaticRetry(Attempts = 0)]
        [Queue("uoko_recurrent_task")]
        void Excute();
    }
}
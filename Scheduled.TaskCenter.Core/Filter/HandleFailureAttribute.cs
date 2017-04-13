using Hangfire.Common;
using Hangfire.Logging;
using Hangfire.States;
using Hangfire.Storage;

namespace Scheduled.TaskCenter.Core.Filter
{
    /// <summary>
    /// 处理失败任务
    /// </summary>
    public class HandleFailureAttribute : JobFilterAttribute, IApplyStateFilter
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();
        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            var failedState = context.NewState as FailedState;
            if (failedState != null)
            {
                //记录日志到Fatal 级别  配置 Fatal 级别的日志 邮件
                Logger.FatalException(
                    $"Background job #{context.BackgroundJob.Id} was failed with an exception.",
                    failedState.Exception);
            }
        }

        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.SqlServer.RabbitMQ;
using Scheduled.TaskCenter.Core;
using Scheduled.TaskCenter.Core.RecurrentTask;

namespace Scheduled.TaskCenter.Server
{
    public class ServiceControl
    {
        private static BackgroundJobServer _server; 
        public void Start()
        {
            var options = new BackgroundJobServerOptions
            {
                ServerName = $"{Environment.MachineName}.{Guid.NewGuid()}",
                Queues=new [] {"uoko_recurrent_task", "jobs" }
            };
            GlobalConfig.InitBasicConfig();
            GlobalConfig.AddFilters();
            _server = new BackgroundJobServer(options);

            LoadRecurringTasks();
        }

        private void LoadRecurringTasks()
        {
            var types =from type in Assembly.Load("Scheduled.TaskCenter.Core").GetTypes()
                       where type.GetInterfaces().Any(t => t== typeof(IRecurringTask)) 
                select type;
            foreach (var type in types)
            {
                var task = (IRecurringTask)Activator.CreateInstance(type);
                RecurringJob.AddOrUpdate(task.JobId, ()=> task.Excute(null), task.CronExpression, queue: "uoko_recurrent_task");
            }

            GlobalConfig.RecurringJob(typeof (RecurringJobService));
        }
        public void Stop()
        {
            _server?.Dispose();
        }
    }
}

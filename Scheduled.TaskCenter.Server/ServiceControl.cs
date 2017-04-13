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
                Queues=new [] {"uoko_recurrent_task"}
            };
            GlobalConfig.InitBasicConfig();
            GlobalConfig.AddFilters();
            _server = new BackgroundJobServer(options);

            LoadRecurringTasks();
        }

        private void LoadRecurringTasks()
        {
            var types =from type in typeof(ServiceControl).Assembly.GetTypes()
                where type.Namespace == "Scheduled.TaskCenter.Server.RecurrentTask" && type.GetInterfaces().Any(t => t== typeof(IRecurringTask)) 
                select type;
            foreach (var type in types)
            {
                var task = (IRecurringTask)Activator.CreateInstance(type);
                RecurringJob.AddOrUpdate(task.JobId, ()=> task.Excute(), task.CronExpression, queue: "uoko_recurrent_task");
            }
        }
        public void Stop()
        {
            _server?.Dispose();
        }
    }
}

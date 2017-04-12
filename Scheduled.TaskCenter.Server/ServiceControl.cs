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
                Queues=new [] {"uoko_recurrent_task" }
            };
            //使用SQLServer作为 数据库存储 RabbitMQ作为 消息队列
            //使用SQLServer作为 数据库存储 RabbitMQ作为 消息队列
            var storage = new SqlServerStorage("TaskCenterDB").UseRabbitMq(
                conf =>
                {
                    conf.HostName = "localhost";
                    conf.Port = 5672;
                    conf.Username = "uoko";
                    conf.Password = "uoko123";
                }
                );
            GlobalConfiguration.Configuration.UseStorage(storage);
            //JobStorage.Current = storage;
            _server = new BackgroundJobServer(options);

            LoadRecurringTasks();
        }

        private void LoadRecurringTasks()
        {
            var types =
                from type in typeof(ServiceControl).Assembly.GetTypes()
                where type.Namespace == "Scheduled.TaskCenter.Server.RecurrentTask" && type.BaseType==typeof(RecurringTaskBase)
                select type;
            foreach (var type in types)
            {
                var task = (RecurringTaskBase)Activator.CreateInstance(type);
                task.AddTask();
            }
        }
        public void Stop()
        {
            _server?.Dispose();
        }
    }
}

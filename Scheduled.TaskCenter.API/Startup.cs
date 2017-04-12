using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.SqlServer.RabbitMQ;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Scheduled.TaskCenter.API.Startup))]

namespace Scheduled.TaskCenter.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
        }
    }
}

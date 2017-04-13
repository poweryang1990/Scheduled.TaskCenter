using System;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.SqlServer.RabbitMQ;
using Microsoft.Owin;
using Owin;
using Scheduled.TaskCenter.Core;

[assembly: OwinStartup(typeof(Scheduled.TaskCenter.API.Startup))]

namespace Scheduled.TaskCenter.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfig.InitBasicConfig();
            GlobalConfig.AddFilters();
        }
    }
}

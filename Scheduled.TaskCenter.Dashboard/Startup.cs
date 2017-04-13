using Hangfire;
using Microsoft.Owin;
using Owin;
using Scheduled.TaskCenter.Core;

[assembly: OwinStartup(typeof(Scheduled.TaskCenter.Dashboard.Startup))]

namespace Scheduled.TaskCenter.Dashboard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfig.InitBasicConfig();
            app.UseHangfireDashboard("/jobs");
        }
    }
}

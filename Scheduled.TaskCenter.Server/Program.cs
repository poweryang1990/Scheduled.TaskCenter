using System;
using Topshelf;

namespace Scheduled.TaskCenter.Server
{
    class Program
    {
        static void Main(string[] args)
        {  
            HostFactory.Run(x =>
            {
                x.RunAsLocalSystem();

                x.SetServiceName("Scheduled.TaskCenter.Server");
                x.SetDisplayName("Scheduled.TaskCenter.Server");
                x.SetDescription("Scheduled.TaskCenter.Server");

                x.Service<ServiceControl>(s =>
                {
                    s.ConstructUsing(name => new ServiceControl());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.SetStartTimeout(TimeSpan.FromMinutes(5));
                //https://github.com/Topshelf/Topshelf/issues/165
                x.SetStopTimeout(TimeSpan.FromMinutes(35));

                x.EnableServiceRecovery(r => { r.RestartService(1); });
            });
        }
    }
}

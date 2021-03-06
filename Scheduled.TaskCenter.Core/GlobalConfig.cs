﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Common;
using Hangfire.Console;
using Hangfire.Logging;
using Hangfire.RecurringJobExtensions;
using Hangfire.SqlServer;
using Hangfire.SqlServer.RabbitMQ;
using Scheduled.TaskCenter.Core.Filter;

namespace Scheduled.TaskCenter.Core
{
    public static class GlobalConfig
    {
        public static void InitBasicConfig()
        {
            //使用SQLServer作为 数据库存储 RabbitMQ作为 消息队列
            var storage = new SqlServerStorage("TaskCenterDB").UseRabbitMq(
                conf =>
                {
                    conf.HostName = "localhost";
                    conf.Port = 5672;
                    conf.Username = "uoko";
                    conf.Password = "uoko123";
                }, "uoko_recurrent_task", "jobs","default");
            GlobalConfiguration.Configuration.UseStorage(storage).UseConsole();
        }

        public static void AddFilters()
        {
            GlobalConfiguration.Configuration.UseFilter(new HandleFailureAttribute());
        }
        public static void RecurringJob(Type type)
        {
            GlobalConfiguration.Configuration.UseRecurringJob(type);
        }

    }
}

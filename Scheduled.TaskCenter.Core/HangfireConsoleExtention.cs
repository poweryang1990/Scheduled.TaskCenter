using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire.Console;
using Hangfire.Server;

namespace Scheduled.TaskCenter.Core
{
    public static class HangfireConsoleExtention
    {
        /// <summary>
        /// 输出警告信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="content"></param>
        public static void WarningWriteLine(this PerformContext context,string content)
        {
            context.SetTextColor(ConsoleTextColor.Yellow);
            context.WriteLine(content);
            context.ResetTextColor();
        }
        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="content"></param>
        public static void ErrorWriteLine(this PerformContext context, string content)
        {
            context.SetTextColor(ConsoleTextColor.Red);
            context.WriteLine(content);
            context.ResetTextColor();
        }
    }
}

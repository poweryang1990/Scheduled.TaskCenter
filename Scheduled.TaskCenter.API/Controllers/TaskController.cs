using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hangfire;

namespace Scheduled.TaskCenter.API.Controllers
{
    public class TaskController : ApiController
    {
        [HttpPost]
        public string Create(int id)
        {
            return BackgroundJob.Enqueue(() => Console.WriteLine($"Task {id}"));
        }

    }
}

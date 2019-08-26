using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITSTracker.Models;
using ITSTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITSTracker.Controllers
{
    [Route("api/[Controller]")]
    public class TasksController : Controller
    {
        private IService service = null;

        public TasksController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<MyTask>> GetTasks()
        {
            return this.service.GetTasks();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<MyTask> Get(int id)
        {
            return this.service.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<MyTask> Add([FromBody] MyTask task)
        {
            var mytask = this.service.Add(task);
            if (mytask == null) return new BadRequestResult();
            return mytask;
        }
    }
}
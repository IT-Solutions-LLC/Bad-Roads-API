using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITSTracker.Models;
using ITSTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITSTracker.Controllers
{
    [Route("/api/[Controller]")]
    public class DeviceController : Controller
    {
        public IDeviceService Service { get; set; }
        public DeviceController(IDeviceService service)
        {
            Service = service;
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult GetDevice(string id)
        {
            var result = this.Service.GetDevice(id);
            if (result == null) return new BadRequestResult();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetDevices()
        {
            var result = this.Service.GetDevices();
            if (result == null) return new BadRequestResult();
            return new JsonResult(result);
        }

        [HttpPost("update")]
        public ActionResult UpdateDevice([FromBody] TcDevices device)
        {
            if(device == null) return BadRequest("Incorrect user");
            var result = this.Service.UpdateDevice(device);
            if (result == null) return BadRequest("Incorrect user");
            return new JsonResult(result);
        }
    }
}
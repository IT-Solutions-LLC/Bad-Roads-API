using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ITSTracker.Models;
using ITSTracker.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ITSTracker.Controllers
{
    [Route("api/[Controller]")]

    public class AccountController : Controller
    {

        private IAccountService accountService = null;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<MyTask>> GetTasks()
        {
            return new BadRequestResult();
        }

        //public async void Token([FromBody] )
        [HttpPost("login")]
        public ActionResult login([FromBody] AccountRequest model)
        {
            var response = this.accountService.Login(model);
            if (response == null) return BadRequest("incorrect login or password");
            return new JsonResult(response);
        }

        [HttpPost("user")]
        //[EnableCors("AllowOrigin")]
        public ActionResult GetUser([FromBody] int id)
        {
            var response = this.accountService.Find(id);
            if (response == null) return BadRequest("Token error");
            return new JsonResult(response);
        }

        [HttpPost("register")]
        //[EnableCors("AllowOrigin")]
        public ActionResult Register([FromBody] AccountRequest model)
        {
            var response = this.accountService.Register(model);
            if (response == null) return BadRequest("User exists");
            return new JsonResult(response);
        }

    }
}
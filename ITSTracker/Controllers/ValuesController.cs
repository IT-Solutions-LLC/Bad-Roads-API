using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITSTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> tasks = new List<string>();

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        // GET api/values
        [HttpGet]
        [Route("get/{z}/{x}/{y}.png")]
        public ActionResult<IEnumerable<string>> GetImage(int z, int x, int y)
        {
            //var img = new Bitmap(256, 256);
            //var data = ImageToByteArray(img);
            FileStream image = null;
            var filepath = $"Tiles/{x}A{y}A{z}.png";
            if (System.IO.File.Exists(filepath))
            {
                image = System.IO.File.OpenRead(filepath);
            }
            else
            {
                image = System.IO.File.OpenRead("Tiles/empty.png");
            }
            return File(image, "image / png");
        }

        // GET api/values/5
        [HttpGet("{task}")]
        public ActionResult<string> Get(string task)
        {
            return tasks.Find((obj) =>
            {
                return obj == task;
            });
        }

        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return new OkResult();
        }

        // POST api/values
        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Post(string task)
        {
            System.Diagnostics.Debug.WriteLine("asdas");
            tasks.Add(task);
            return new RedirectResult("test");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}

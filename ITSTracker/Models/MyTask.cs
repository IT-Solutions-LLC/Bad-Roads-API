using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSTracker.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Title { get; set  ; }

        public string Content { get; set; }

        public override string ToString()
        {
            return $"Task: id - {this.Id}, title - {this.Title}, content - {this.Content}";
        }
    }
}

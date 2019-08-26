using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcCommands
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool? Textchannel { get; set; }
        public string Attributes { get; set; }
    }
}

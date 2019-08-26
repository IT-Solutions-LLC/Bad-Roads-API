using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcAttributes
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public string Expression { get; set; }
    }
}

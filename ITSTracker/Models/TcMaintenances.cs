using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcMaintenances
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Start { get; set; }
        public double Period { get; set; }
        public string Attributes { get; set; }
    }
}

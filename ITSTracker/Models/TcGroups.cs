using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcGroups
    {
        public TcGroups()
        {
            InverseGroup = new HashSet<TcGroups>();
            TcDevices = new HashSet<TcDevices>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Groupid { get; set; }
        public string Attributes { get; set; }

        public TcGroups Group { get; set; }
        public ICollection<TcGroups> InverseGroup { get; set; }
        public ICollection<TcDevices> TcDevices { get; set; }
    }
}

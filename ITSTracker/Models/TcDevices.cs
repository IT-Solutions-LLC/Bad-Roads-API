using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcDevices
    {
        public TcDevices()
        {
            TcEvents = new HashSet<TcEvents>();
            TcPositions = new HashSet<TcPositions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Uniqueid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public int? Positionid { get; set; }
        public int? Groupid { get; set; }
        public string Attributes { get; set; }
        public string Phone { get; set; }
        public string Model { get; set; }
        public string Contact { get; set; }
        public string Category { get; set; }
        public bool? Disabled { get; set; }
        public double? Mileage { get; set; }
        public double? MotoTime { get; set; }

        public TcGroups Group { get; set; }
        public ICollection<TcEvents> TcEvents { get; set; }
        public ICollection<TcPositions> TcPositions { get; set; }
    }
}

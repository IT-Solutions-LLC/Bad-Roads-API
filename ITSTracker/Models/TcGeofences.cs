using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcGeofences
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
        public string Attributes { get; set; }
        public int? Calendarid { get; set; }

        public TcCalendars Calendar { get; set; }
    }
}

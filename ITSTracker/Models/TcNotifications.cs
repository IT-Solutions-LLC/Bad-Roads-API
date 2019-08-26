using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcNotifications
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Attributes { get; set; }
        public bool? Always { get; set; }
        public int? Calendarid { get; set; }
        public string Notificators { get; set; }

        public TcCalendars Calendar { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcCalendars
    {
        public TcCalendars()
        {
            TcGeofences = new HashSet<TcGeofences>();
            TcNotifications = new HashSet<TcNotifications>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string Attributes { get; set; }

        public ICollection<TcGeofences> TcGeofences { get; set; }
        public ICollection<TcNotifications> TcNotifications { get; set; }
    }
}

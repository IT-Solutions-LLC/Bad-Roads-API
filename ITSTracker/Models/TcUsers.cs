using System;
using System.Collections.Generic;

namespace ITSTracker.Models
{
    public partial class TcUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Hashedpassword { get; set; }
        public string Salt { get; set; }
        public bool? Readonly { get; set; }
        public bool? Administrator { get; set; }
        public string Map { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zoom { get; set; }
        public bool? Twelvehourformat { get; set; }
        public string Attributes { get; set; }
        public string Coordinateformat { get; set; }
        public bool? Disabled { get; set; }
        public DateTime? Expirationtime { get; set; }
        public int? Devicelimit { get; set; }
        public string Token { get; set; }
        public int? Userlimit { get; set; }
        public bool? Devicereadonly { get; set; }
        public string Phone { get; set; }
        public bool? Limitcommands { get; set; }
        public string Login { get; set; }
        public string Poilayer { get; set; }
    }
}

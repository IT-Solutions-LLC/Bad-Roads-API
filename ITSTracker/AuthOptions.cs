﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSTracker
{
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public string Key { get; set; }

        public int LifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.Default.GetBytes(this.Key));
        }
    }
}

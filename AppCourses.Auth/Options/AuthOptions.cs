﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppCourses.Auth.Options
{
    public class AuthOptions
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? Secret { get; set; }
        public double? TokenLifeTime { get; set; }
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF32.GetBytes(Secret));
        }
    }
}

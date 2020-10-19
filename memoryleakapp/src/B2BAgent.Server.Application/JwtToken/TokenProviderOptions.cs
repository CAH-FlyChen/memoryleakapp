//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EV.Identity
//{

//    public class JwtTokenOptions : IOptions<JwtTokenOptions>
//    {
//        //public string Path { get; set; } = "/auth/token";
//        //public string RefreshTokenPath { get; set; } = "/auth/refresh_token";
//        //public IConfigurationRoot config { get; set; }

//        public string Issuer { get; set; }
//        public string Audience { get; set; }
//        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(10);
//        public SigningCredentials SigningCredentials { get; set; }

//        public JwtTokenOptions Value => this;
        
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class JWTResponse
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}
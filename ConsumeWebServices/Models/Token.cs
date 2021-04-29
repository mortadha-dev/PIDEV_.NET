using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class Token
    {
      
            public string username { get; set; }
            public string role { get; set; }
            public string accessToken { get; set; }
            public string tokenType { get; set; }
        


    }
}
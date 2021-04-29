using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class Payment
    {

        public String amount { get; set; }
        public String paymentMean { get; set; }
        public User user { get; set; }
      
    }

}
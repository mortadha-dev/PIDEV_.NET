using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class CardDetails
    {
        public int number { get; set; }

        public int expMonth { get; set; }
        public int expYear { get; set; }

        public String cvc { get; set; }


    }
}
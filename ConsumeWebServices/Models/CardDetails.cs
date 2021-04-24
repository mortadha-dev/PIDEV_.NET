using System;

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
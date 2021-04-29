using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class Loyaltycard
    {
        public int price { get; set; }

        public int randomgift { get; set; }

        public int idcard { get; set; }

        public User user { get; set; }




    }
}
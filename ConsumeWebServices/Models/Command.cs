using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class Command
    {

        public int id { get; set; }
        public String dateComm { get; set; }
        public String etatcommande { get; set; }
        public float montant { get; set; }

    }
}
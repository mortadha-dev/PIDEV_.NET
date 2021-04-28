using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Decision
    {
        public int idDecision { get; set; }
        public DateTime dateRefund { get; set; }
        public DateTime dateExchange { get; set; }
        public DateTime dateRepair { get; set; }
        public DateTime dateLARepair { get; set; }
        public string devis { get; set; }
        public TypeDecision typeDecision { get; set; }




    }
}
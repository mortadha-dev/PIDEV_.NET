using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Claim
    {
        public long idClaim { get; set; }
        public string descriptionClaim { get; set; }
        public DateTime dateClaim { get; set; }
        public TypeClaim typeClaim { get; set; }
        
        // foreign Key properties
        //public long? idCommande { get; set; }
        public Decision idDecision { get; set; }
        public Commande idCommande { get; set; }
        /*  public Claim()
          {
              idCommande = new Commande();
          }
          */
       
    }
}
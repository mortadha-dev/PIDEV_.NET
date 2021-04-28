using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Commande
    {
        public long idCommande { get; set; }
        // foreign Key properties
        public virtual Collection<Claim> claim { get; set; }
        public virtual Collection<Livraison> livraison { get; set; }
    }
    
}

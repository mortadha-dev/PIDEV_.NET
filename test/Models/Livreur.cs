using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
//
namespace test.Models
{
    public class Livreur
    {
        public long id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public Disponibilit disponibilit { get; set; }

        public string disponibility
        {
            get
            {
                if (disponibilit == Disponibilit.ACTIVE) return "Active";
                else return "Inactive";
            }
            set {
                if (value == "Active") disponibilit = Disponibilit.ACTIVE;
                else disponibilit = Disponibilit.NOACTIVE;
            }
        }
        // foreign Key properties
        public virtual Collection<Livraison> livraisons { get; set; }
    }
}
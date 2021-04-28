using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Livraison
    {
        public long id { get; set; }
        public string destination { get; set; }
        public double distance { get; set; }
        public double frais { get; set; }
        public DateTime? date{ get; set; }
        public State state { get; set; }
        public  Collection<Livraison> livraisons { get; set; }
        // foreign Key properties
        /*public string State
        {
            get
            {
                if (State == State.BLOCKED)
                {
                    return "blocked";
                }
                else if (State == State.ENATTENTE)
                {
                    return "enattente";
                }
                else if (State == State.ENCOURS)
                {
                    return "encours";
                }
                else return "livré";
            }
            set
            {
                if (value == "blocked")
                {
                    State = State.BLOCKED;
                }
                else if (value == "enattente")
                {
                    State = State.ENATTENTE;
                }
                else if (value == "encours")
                {
                    State = State.ENCOURS;
                }
                else State = State.LIVRE;
            }
        }
        */
        public Livreur idLivreur { get; set; }
        public Commande idCommande { get; set; }
        public Livraison()
        {
            idLivreur = new Livreur();
            idCommande = new Commande();
        }

    }
    

    }

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceVoyage.Models
{
    public class Client
    {
        public int idClient { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string adresse { get; set; }
        public string ville { get; set; }
        public string codePostal { get; set; }
        public string modePaiement { get; set; }

        public ICollection<Voyage> Voyages { get; set; }
    }
}

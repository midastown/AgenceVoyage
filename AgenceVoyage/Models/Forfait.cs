using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceVoyage.Models
{
    public class Forfait
    {

        public int idForfait { get; set; }
        public string nomForfait { get; set; }
        public string destination { get; set; }
        public double prix { get; set; }
        public int duree { get; set; }
        public string image { get; set; }

        public ICollection<Voyage> Voyages { get; set; }
    }
}

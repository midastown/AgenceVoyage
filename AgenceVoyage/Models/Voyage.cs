using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceVoyage.Models
{
    public class Voyage
    {

        public int idClient { get; set; }
        public int idForfait { get; set; }
        public DateTime dateVoyage { get; set; }
        public Client Client { get; set; }
        public Forfait Forfait { get; set; }
    }
}

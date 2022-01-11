using AgenceVoyage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenceVoyage.Data
{
    public class DbInitializer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        internal static void Initialize(VoyageContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return;
            }

            var clients = new Client[]
            {
                new Client{nom="Mehdi", prenom="Hachimi", adresse="11 rue champ", ville="montreal", codePostal="h2v3u3", modePaiement="carte"}
            };

            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }

            context.SaveChanges();

            var forfaits = new Forfait[]
            {
                new Forfait{ nomForfait="Escapade romantique", destination="Maroc", prix=1220, duree=12, image="maroc.jpg"},
                new Forfait{ nomForfait="La traversée du désert", destination="Maroc", prix=1820, duree=13, image="maroc.jpg"},
                new Forfait { nomForfait="Découverte du Jetset", destination = "Abu Dhabi", prix = 2450, duree = 8, image = "AbuDhabi.jpg" },
                new Forfait { nomForfait="Outback en jeep", destination = "Australie", prix = 2200, duree = 9, image = "Australie.jpg" },
                new Forfait { nomForfait="Plaisirs gastronomiques", destination = "Grece", prix = 2489, duree = 12, image = "Grece.jpg" },
                new Forfait { nomForfait="Expédition au Mont Fudji", destination = "Japon", prix = 1985, duree = 7, image = "Japon.jpg" },
                new Forfait { nomForfait="Resort Au repos", destination = "République Dominicaine", prix = 1240, duree = 7, image = "RepDom.jpg" },
                new Forfait { nomForfait="Resort La fête", destination = "République Dominicaine", prix = 1400, duree = 7, image = "RepDom.jpg" },
                new Forfait { nomForfait="Tour Nord du Pays", destination = "Thaïlande", prix = 3458, duree = 15, image = "Thailande.jpg" },
                new Forfait { nomForfait="Tour Sud du Pays", destination = "Thaïlande", prix = 3234, duree = 14, image = "Thailande.jpg" }
            };

            foreach (Forfait f in forfaits)
            {
                context.Forfaits.Add(f);
            }

            context.SaveChanges();

            //var voyages = new Voyage[]
            //{
            //    new Voyage{}
            //};

            //foreach (Voyage v in voyages)
            //{
            //    context.Voyages.Add(v);
            //}

            //context.SaveChanges();
        }
    }
}

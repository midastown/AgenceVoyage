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
                new Forfait{destination="Maroc", prix=1220, duree=3, image="maroc.jpg"},
                new Forfait { destination = "Abu Dhabi", prix = 1460, duree = 3, image = "AbuDhabi.jpg" },
                new Forfait { destination = "Australie", prix = 12.2, duree = 3, image = "Australie.jpg" },
                new Forfait { destination = "Grece", prix = 12.2, duree = 3, image = "Grece.jpg" },
                new Forfait { destination = "Japon", prix = 12.2, duree = 3, image = "Japon.jpg" },
                new Forfait { destination = "République Dominicaine", prix = 12.2, duree = 3, image = "RepDom.jpg" },
                new Forfait { destination = "Thaïlande", prix = 12.2, duree = 3, image = "Thailande.jpg" }
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

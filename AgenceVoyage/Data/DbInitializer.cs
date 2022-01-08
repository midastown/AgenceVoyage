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
                new Forfait{destination="Maroc", prix=12.2, duree=3}
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

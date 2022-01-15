using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgenceVoyage.Models;

namespace AgenceVoyage.Data
{
    public class VoyageContext : DbContext
    {
        public VoyageContext (DbContextOptions<VoyageContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Forfait> Forfaits { get; set; }
        public DbSet<Voyage> Voyages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(x => x.idClient);
            modelBuilder.Entity<Forfait>().HasKey(x => x.idForfait);
            modelBuilder.Entity<Voyage>().HasKey(x => new {x.idClient, x.idForfait});
        }
        
    }
}

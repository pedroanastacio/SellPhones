using SellPhones.Celulares.Business;
using SellPhones.Celulares.Data.Entity.TypeConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Celulares.Data.Entity.Context
{
    public class CelularDbContext : DbContext
    {
        public DbSet<Celular> Celulares { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CelularDbContext>(null);
            modelBuilder.Configurations.Add(new CelularTypeConfiguration());
            modelBuilder.Configurations.Add(new MarcaTypeConfiguration());
        }
    }
}

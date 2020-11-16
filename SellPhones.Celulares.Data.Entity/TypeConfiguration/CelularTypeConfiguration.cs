using SellPhones.Celulares.Business;
using SellPhones.Celulares.Generic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Celulares.Data.Entity.TypeConfiguration
{
    class CelularTypeConfiguration : SellPhonesEntityAbstractConfig<Celular>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdCelular)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdCelular");

            Property(p => p.Modelo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Modelo");

            Property(p => p.IdMarca)
                .IsRequired()
                .HasColumnName("IdMarca");

            Property(p => p.Cor)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Cor");

            Property(p => p.Preco)
                .IsRequired()
                .HasColumnName("Preco");

            Property(p => p.Imei)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("Imei");

        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(c => c.Marca)
            .WithMany(m => m.Celulares)
            .HasForeignKey(c => c.IdMarca);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.IdCelular);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Celular");
        }
    }
}

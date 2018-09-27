using SantosSantana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dados.Map
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public ContaMap()
        {
            ToTable("Conta");

            Property(x => x.ContaId).IsRequired();
            Property(x => x.NumConta).IsRequired().HasColumnType("varchar").HasMaxLength(6);
            Property(x => x.NumAgencia).IsRequired().HasColumnType("varchar").HasMaxLength(4);
            Property(x => x.Saldo).IsRequired();
            Property(x => x.Limite).IsRequired();
       }

    }
}

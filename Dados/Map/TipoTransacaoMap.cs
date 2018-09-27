using SantosSantana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dados.Map
{
    public class TipoTransacaoMap : EntityTypeConfiguration<TipoTransacao>
    {
        public TipoTransacaoMap()
        {
            ToTable("TipoTransacao");

            Property(x => x.TipoTransacaoId).IsRequired();
            Property(x => x.Descricao).IsRequired().HasColumnType("varchar").HasMaxLength(20);
        }

    }
}

using SantosSantana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dados.Map
{
    public class TransacaoMap : EntityTypeConfiguration<Transacao>
    {
        public TransacaoMap()
        {
            ToTable("Transacao");

            Property(x => x.TransacaoId).IsRequired();
            Property(x => x.Valor).IsRequired();
            Property(x => x.Data).IsRequired();
            Property(x => x.TipoTransacaoId).IsRequired();
            Property(x => x.ContaId).IsRequired();
     
       }

    }

}

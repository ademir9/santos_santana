

using SantosSantana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dados.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            
            Property(x => x.UsuarioId).IsRequired();
            Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(70);
            Property(x => x.CPF).IsRequired().HasColumnType("varchar").HasMaxLength(14);
            Property(x => x.Sexo).IsOptional().HasColumnType("char").HasMaxLength(1);
            Property(x => x.DataNasc).IsRequired();
            Property(x => x.Senha).IsRequired().HasColumnType("varchar").HasMaxLength(100);
        }

    }
}

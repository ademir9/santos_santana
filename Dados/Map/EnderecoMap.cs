using SantosSantana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dados.Map
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Endereco");

            Property(x => x.EnderecoId).IsRequired();
            Property(x => x.CEP).IsOptional().HasColumnType("varchar").HasMaxLength(9);
            Property(x => x.Logradouro).HasColumnType("varchar").IsRequired().HasMaxLength(250);
            Property(x => x.Numero).IsOptional().HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.Complemento).IsOptional().HasColumnType("varchar").HasMaxLength(250);
            Property(x => x.Bairro).IsOptional().HasColumnType("varchar").HasMaxLength(250);
            Property(x => x.Cidade).IsOptional().HasColumnType("varchar").HasMaxLength(250);
            Property(x => x.UF).IsOptional().HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.Bairro).IsOptional().HasColumnType("varchar").HasMaxLength(250);
            
        }

    }
}

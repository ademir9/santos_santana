using SantosSantana.Dados.Map;
using SantosSantana.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dados
{
    public class Contexto : DbContext
    {
        public Contexto() : base("conn")
        {
          
           // Database.SetInitializer<Contexto>(new CreateDatabaseIfNotExists<Contexto>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;

        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }
        public virtual DbSet<TipoTransacao> TipoTransacao { get; set; }
       

        






        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
     

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Conta>().ToTable("Conta");
            modelBuilder.Entity<Transacao>().ToTable("Transacao");
            modelBuilder.Entity<TipoTransacao>().ToTable("TipoTransacao");
            
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new ContaMap());
            modelBuilder.Configurations.Add(new TransacaoMap());
            modelBuilder.Configurations.Add(new TipoTransacaoMap());
      
        }
    }
}

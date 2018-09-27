namespace SantosSantana.Dados.Migrations
{
    using SantosSantana.Dominio.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SantosSantana.Dados.Contexto>
    {
        public Configuration()
        {
          //  AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SantosSantana.Dados.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.TipoTransacao.AddOrUpdate(
              p => p.Descricao,
              new TipoTransacao { Descricao = "Depósito" },
              new TipoTransacao { Descricao = "Saque" },
              new TipoTransacao { Descricao = "Transferência" }
            );
        }
    }
}

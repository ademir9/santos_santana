namespace SantosSantana.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conta",
                c => new
                    {
                        ContaId = c.Int(nullable: false, identity: true),
                        NumConta = c.String(nullable: false, maxLength: 6, unicode: false),
                        NumAgencia = c.String(nullable: false, maxLength: 4, unicode: false),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Limite = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ContaId);
            
            CreateTable(
                "dbo.Transacao",
                c => new
                    {
                        TransacaoId = c.Int(nullable: false, identity: true),
                        ContaId = c.Int(nullable: false),
                        TipoTransacaoId = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransacaoId)
                .ForeignKey("dbo.Conta", t => t.ContaId)
                .ForeignKey("dbo.TipoTransacao", t => t.TipoTransacaoId)
                .Index(t => t.ContaId)
                .Index(t => t.TipoTransacaoId);
            
            CreateTable(
                "dbo.TipoTransacao",
                c => new
                    {
                        TipoTransacaoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.TipoTransacaoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        CEP = c.String(maxLength: 9, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 250, unicode: false),
                        Numero = c.String(maxLength: 10, unicode: false),
                        Complemento = c.String(maxLength: 250, unicode: false),
                        Bairro = c.String(maxLength: 250, unicode: false),
                        Cidade = c.String(maxLength: 250, unicode: false),
                        UF = c.String(maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 70, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 14, unicode: false),
                        Sexo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        DataNasc = c.DateTime(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 100, unicode: false),
                        ContaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Conta", t => t.ContaId)
                .Index(t => t.ContaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "ContaId", "dbo.Conta");
            DropForeignKey("dbo.Transacao", "TipoTransacaoId", "dbo.TipoTransacao");
            DropForeignKey("dbo.Transacao", "ContaId", "dbo.Conta");
            DropIndex("dbo.Endereco", new[] { "UsuarioId" });
            DropIndex("dbo.Usuario", new[] { "ContaId" });
            DropIndex("dbo.Transacao", new[] { "TipoTransacaoId" });
            DropIndex("dbo.Transacao", new[] { "ContaId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Endereco");
            DropTable("dbo.TipoTransacao");
            DropTable("dbo.Transacao");
            DropTable("dbo.Conta");
        }
    }
}

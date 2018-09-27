using SantosSantana.Dominio.Models;
using SantosSantana.Dados;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace SantosSantana.Servicos
{
    public class ServicoUsuario
    {
        public bool Acessar(string conta, string agencia, string senha)
        {
            using (Contexto db = new Contexto())
            {
                var dado = db.Usuario.FirstOrDefault(m => m.Conta.NumConta == conta && m.Conta.NumAgencia == agencia);
                if(dado != null && dado.Senha == senha) {
                    return true;
                }
            }
            return false;
        }

        public List<Usuario> ListarUsuarios()
        {

            using (Contexto db = new Contexto())
            {
                try
                {
                    return db.Usuario.Include(m => m.Conta).ToList();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {

                        var tt = eve.Entry.Entity.GetType().Name;
                        var t = eve.Entry.State;
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var ttr = ve.PropertyName;
                            var gf = ve.ErrorMessage;
                        }
                    }
                    throw;
                }

            }
        }

        public Usuario BuscarUsuario(string conta, string agencia)
        {
            using (Contexto db = new Contexto())
            {
                db.Configuration.LazyLoadingEnabled = false;
               return db.Usuario.Include(m=>m.Conta).FirstOrDefault(m=>m.Conta.NumConta == conta && m.Conta.NumAgencia == agencia);
            }
        }

        public bool CriarUsuario(Usuario usuario)
        {
            try
            {
                using (Contexto db = new Contexto())
                {
                    var dado = db.Usuario.Where(m => m.CPF == usuario.CPF).FirstOrDefault();

                    if (dado != null)
                        throw new Exception("CPF já consta em nosso cadastro.");

                    Conta novaConta = new Conta();
                    novaConta.NumConta = string.Format(@"{0:0000\-0}", Convert.ToDouble(DateTime.Now.ToString("mmHss").Substring(0, 5)));
                    novaConta.NumAgencia = string.Format(@"{0:0000}", Convert.ToDouble(DateTime.Now.ToString("mmHss").Substring(0, 4)));
                    novaConta.Limite = ObterLimite();
                    novaConta.Saldo = 0;

                    usuario.Conta = novaConta;
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        private decimal ObterLimite()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 1800);
        }
        
        public Conta BuscaConta(string conta)
        {

            using (Contexto db = new Contexto())
            {

                return db.Conta.FirstOrDefault(a => a.NumConta == conta);
            }
        }

      
    }


}

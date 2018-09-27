using SantosSantana.Dominio.Models;
using SantosSantana.Servicos.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SantosSantana.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [Authorize]
        [HttpGet]
        public Usuario BuscarUsuario(string conta, string agencia)
        {
            Servicos.ServicoUsuario serv = new Servicos.ServicoUsuario();

            try
            {
                return serv.BuscarUsuario(conta, agencia);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);

            }


        }


        [HttpPost]
        public RespostaJson CriarUsuario(Usuario usuario)
        {
            RespostaJson resposta;
            try
            {

                Servicos.ServicoUsuario serv = new Servicos.ServicoUsuario();
                serv.CriarUsuario(usuario);

            }
            catch (System.Exception ex)
            {
                resposta = new RespostaJson() { Status = "false", Msg = ex.Message };
            }

            return new RespostaJson() { Status = "true", Msg = "Cadastro efetuado com sucesso" };
        }

        [HttpGet]
        public ICollection<Usuario> ListarUsuarios()
        {
            Servicos.ServicoUsuario serv = new Servicos.ServicoUsuario();

            return serv.ListarUsuarios();


        }
    }
}
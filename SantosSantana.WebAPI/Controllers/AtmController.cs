using SantosSantana.Dominio.Models;
using SantosSantana.Servicos.Util;
using System.Collections.Generic;
using System.Web.Http;


namespace SantosSantana.WebAPI.Controllers
{
    public class AtmController : ApiController
    {
        [Authorize]
        [HttpGet]
        public RespostaJson EfetuarTransacao(string cpf, string contaDestino, string agenciaDestino, decimal valor, int tipo)
        {
            Servicos.ServicoAtm serv = new Servicos.ServicoAtm();
            RespostaJson retorno = new RespostaJson();
            try
            {
                switch (tipo)
                {
                    case 1:
                        serv.EfetuarDeposito(contaDestino, agenciaDestino, valor);
                        retorno = new RespostaJson() { Status = "true", Msg = "Deposito efetuado com sucesso" };
                        break;
                    case 3:
                        serv.EfetuarTransferencia(cpf, contaDestino, agenciaDestino, valor);
                        retorno = new RespostaJson() { Status = "true", Msg = "Transferência efetuado com sucesso" };
                        break;
                }

                return retorno;
            }
            catch (System.Exception ex)
            {
                return new RespostaJson() { Status = "false", Msg = ex.Message };
            }
        }


        [Authorize]
        [HttpGet]
        public RespostaJson EfetuarSaque(string cpf, decimal valor)
        {
            Servicos.ServicoAtm serv = new Servicos.ServicoAtm();

            try
            {
                serv.EfetuarSaque(cpf, valor);
                return new RespostaJson() { Status = "true", Msg = "Saque efetuado com sucesso" };
            }
            catch (System.Exception ex)
            {
                return new RespostaJson() { Status = "false", Msg = ex.Message };
            }
        }

        [Authorize]
        [HttpGet]
        public ICollection<Transacao> EfetuarExtrato(string cpf)
        {
            Servicos.ServicoAtm serv = new Servicos.ServicoAtm();

            return serv.EfetuarExtrato(cpf);

        }



    }
}
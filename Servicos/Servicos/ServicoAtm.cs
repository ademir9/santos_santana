using SantosSantana.Dados;
using SantosSantana.Dominio.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Servicos
{
    public class ServicoAtm
    {

        public bool EfetuarDeposito(string contaDestino, string agenciaDestino, decimal valor)
        {
            try
            {
                using (Contexto db = new Contexto())
                {
                    var usuarioDestino = db.Usuario.Include(a => a.Conta).FirstOrDefault(m => m.Conta.NumConta == contaDestino && m.Conta.NumAgencia == agenciaDestino);

                    if (usuarioDestino == null)
                        throw new Exception("Conta de destino não encontrada.");

                   
                    if (usuarioDestino != null)
                    {
                        if (valor > 800)
                            throw new Exception("Limite de depósito é de R$ 800,00.");

                        Transacao trans = new Transacao();
                        usuarioDestino.Conta.Saldo += valor;

                        trans = new Transacao()
                        {
                            ContaId = usuarioDestino.Conta.ContaId,
                            Data = DateTime.Now,
                            TipoTransacaoId = 1,
                            Valor = valor
                        }; //TipoTransacaoId(1- Depósito, 2- Saque, 3- Transferência)

                        db.Transacao.Add(trans);
                        db.SaveChanges();

                        return true;

                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EfetuarTransferencia(string cpf, string contaDestino, string agenciaDestino, decimal valor)
        {
            try
            {
                using (Contexto db = new Contexto())
                {
                    var usuario = db.Usuario.Include(a => a.Conta).FirstOrDefault(m => m.CPF == cpf);
                    var usuarioDestino = db.Usuario.Include(a => a.Conta).FirstOrDefault(m => m.Conta.NumConta == contaDestino && m.Conta.NumAgencia == agenciaDestino);

                    if (usuarioDestino == null)
                        throw new Exception("Conta de destino não encontrada.");


                    if (usuario != null)
                    {
                        Transacao trans = new Transacao();
                        if (usuario.Conta.Saldo > valor)
                        {
                            usuario.Conta.Saldo = (usuario.Conta.Saldo - valor);

                            trans = new Transacao()
                            {
                                ContaId = usuario.Conta.ContaId,
                                Data = DateTime.Now,
                                TipoTransacaoId = 3,
                                Valor = (-valor)
                            }; //TipoTransacaoId(1- Depósito, 2- Saque, 3- Transferência)
                        }
                        else if ((usuario.Conta.Saldo + usuario.Conta.Limite) > valor)
                        {
                            usuario.Conta.Saldo = (usuario.Conta.Saldo - valor);

                            trans = new Transacao()
                            {
                                ContaId = usuario.Conta.ContaId,
                                Data = DateTime.Now,
                                TipoTransacaoId = 3,
                                Valor = (-valor)
                            }; //TipoTransacaoId(1- Depósito, 2- Saque, 3- Transferência)
                        }
                        else
                        {
                            throw new Exception("Saldo insuficiente");
                        }

                        db.Transacao.Add(trans);
                     
                    }
                    else
                    {
                        throw new Exception("Saldo insuficiente");
                    }

                    if (usuarioDestino != null)
                    {
                        Transacao trans = new Transacao();
                        usuarioDestino.Conta.Saldo += valor;

                        trans = new Transacao()
                        {
                            ContaId = usuarioDestino.Conta.ContaId,
                            Data = DateTime.Now,
                            TipoTransacaoId = 3,
                            Valor = valor
                        }; //TipoTransacaoId(1- Depósito, 2- Saque, 3- Transferência)

                        db.Transacao.Add(trans);
                        db.SaveChanges();

                        return true;

                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EfetuarSaque(string cpf, decimal valor)
        {
            try
            {
                using (Contexto db = new Contexto())
                {
                    var usuario = db.Usuario.Include(a => a.Conta).FirstOrDefault(m => m.CPF == cpf);
                    if (usuario != null)
                    {
                        Transacao trans = new Transacao();
                        if (usuario.Conta.Saldo > valor)
                        {
                            usuario.Conta.Saldo = (usuario.Conta.Saldo - valor);

                            trans = new Transacao()
                            {
                                ContaId = usuario.Conta.ContaId,
                                Data = DateTime.Now,
                                TipoTransacaoId = 2,
                                Valor = valor
                            }; //TipoTransacaoId(1- Depósito, 2- Saque, 3- Transferência)
                        }
                        else if ((usuario.Conta.Saldo + usuario.Conta.Limite) > valor)
                        {
                            usuario.Conta.Saldo = (usuario.Conta.Saldo - valor);

                            trans = new Transacao()
                            {
                                ContaId = usuario.Conta.ContaId,
                                Data = DateTime.Now,
                                TipoTransacaoId = 2,
                                Valor = valor
                            }; //TipoTransacaoId(1- Depósito, 2- Saque, 3- Transferência)
                        }
                        else
                        {
                            throw new Exception("Saldo insuficiente");
                        }

                        db.Transacao.Add(trans);
                        db.SaveChanges();

                        return true;

                    }
                    else
                    {
                        throw new Exception("Saldo insuficiente");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<Transacao> EfetuarExtrato(string cpf)
        {
            try
            {
                using (Contexto db = new Contexto())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var usuario = db.Usuario.FirstOrDefault(m => m.CPF == cpf);

                    var data = DateTime.Today.AddDays(-7);
                    var transacoes = db.Transacao.Include(a => a.Conta).Include(a => a.TipoTransacao).Where(m => m.ContaId == usuario.ContaId && m.Data >= data).ToList();


                    foreach (var item in transacoes)
                    {
                        item.Conta.Transacoes = null;
                    }

                    return transacoes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}

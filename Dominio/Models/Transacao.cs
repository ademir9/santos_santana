using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dominio.Models
{
    public class Transacao
    {
        [Key]
        public int TransacaoId { get; set; }
        public int ContaId { get; set; }
        public int TipoTransacaoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public virtual TipoTransacao TipoTransacao { get; set; }
        public virtual Conta Conta { get; set; }

    }
}

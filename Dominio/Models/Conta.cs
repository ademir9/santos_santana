
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dominio.Models
{
    public class Conta
    {
        [Key]
        public int ContaId { get; set; }
        public string NumConta { get; set; }
        public string NumAgencia { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public virtual ICollection<Transacao> Transacoes { get; set; }
       
    }
}

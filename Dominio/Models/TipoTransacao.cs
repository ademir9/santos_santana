using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dominio.Models
{
    public class TipoTransacao
    {
        [Key]
        public int TipoTransacaoId { get; set; }
        public string Descricao { get; set; }
    }
}

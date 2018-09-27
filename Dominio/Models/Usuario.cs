using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SantosSantana.Dominio.Models
{
    public class Usuario
    {
        
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataNasc { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public int ContaId { get; set; }
        public virtual Conta Conta { get; set; }


    }
}

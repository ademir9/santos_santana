using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosSantana.Dominio.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

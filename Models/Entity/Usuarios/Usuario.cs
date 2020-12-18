using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Clientes;
using HashidsNet;

namespace apiEmprestimoJogos.Models.Entity.Usuarios {
    public class Usuario {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Codigo { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Senha { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
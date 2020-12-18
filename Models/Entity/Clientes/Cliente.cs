using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using apiEmprestimoJogos.Models.Entity.Usuarios;

namespace apiEmprestimoJogos.Models.Entity.Clientes {
    public class Cliente {
        [Key]
        public int Id { get; set; }

        [ForeignKey ("Usuario")]
        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdUsuario { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int Codigo { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Telefone { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
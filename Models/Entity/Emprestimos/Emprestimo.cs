using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apiEmprestimoJogos.Models.Entity.Clientes;
using apiEmprestimoJogos.Models.Entity.Jogos;

namespace apiEmprestimoJogos.Models.Entity.Emprestimos {
    public class Emprestimo {
        [Key]
        public int Id { get; set; }

        [ForeignKey ("Jogo")]
        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdJogo { get; set; }

        [ForeignKey ("Cliente")]
        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdCliente { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int CodigoCliente { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DevolucaoPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Jogo Jogo { get; set; }
        public Cliente Cliente { get; set; }

    }
}
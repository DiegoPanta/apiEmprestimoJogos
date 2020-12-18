using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using apiEmprestimoJogos.Models.Entity.Generos;
using apiEmprestimoJogos.Models.Entity.Midias;
using apiEmprestimoJogos.Models.Entity.Tipos;

namespace apiEmprestimoJogos.Models.Entity.Jogos {
    public class Jogo {
        [Key]
        public int Id { get; set; }

        [ForeignKey ("Tipo")]
        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdTipo { get; set; }

        [ForeignKey ("Genero")]
        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdGenero { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdMidia { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int Codigo { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int Ano { get; set; }

        public Tipo Tipo { get; set; }
        public Genero Genero { get; set; }
        public Midia Midia { get; set; }
        
        public ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
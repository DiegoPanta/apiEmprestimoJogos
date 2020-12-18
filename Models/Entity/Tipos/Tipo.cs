using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Jogos;

namespace apiEmprestimoJogos.Models.Entity.Tipos {
    public class Tipo {

        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }

        public ICollection<Jogo> Jogos { get; set; }
    }
}
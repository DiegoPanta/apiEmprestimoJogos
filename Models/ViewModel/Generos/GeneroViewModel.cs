using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Generos;

namespace apiEmprestimoJogos.Models.ViewModel.Generos {
    public class GeneroViewModel {
        [Display (Name = "descricao"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }

        public Genero MapTo (Genero genero) {
            if (genero != null) {
                genero.Descricao = Descricao;
            }

            return genero;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Tipos;

namespace apiEmprestimoJogos.Models.ViewModel.Tipos {
    public class TipoViewModel {
        [Display(Name = "descricao"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }

        public Tipo MapTo(Tipo tipo)
        {
            if(tipo != null)
            {
                tipo.Descricao = Descricao;
            }

            return tipo;
        }
    }
}
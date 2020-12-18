using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Midias;

namespace apiEmprestimoJogos.Models.ViewModel.Midias
{
    public class MidiaViewModel
    {
        [Display (Name = "descricao"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Descricao { get; set; }

        public Midia MapTo (Midia midia) {
            if (midia != null) {
                midia.Descricao = Descricao;
            }

            return midia;
        }
    }
}
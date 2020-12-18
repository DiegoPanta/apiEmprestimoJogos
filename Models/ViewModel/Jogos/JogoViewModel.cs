using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Jogos;

namespace apiEmprestimoJogos.Models.ViewModel.Jogos
{
    public class JogoViewModel
    {
        [Display(Name = "idTipo"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdTipo { get; set; }

        [Display(Name = "idGenero"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdGenero { get; set; }

        [Display(Name = "idMidia"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdMidia { get; set; }

        [Display(Name = "codigo"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int Codigo { get; set; }

        [Display(Name = "nome"), Required (ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "ano"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int Ano { get; set; }


        public Jogo MapTo(Jogo jogo)
        {
            if(jogo != null){
                jogo.IdTipo = IdTipo;
                jogo.IdGenero = IdGenero;
                jogo.Codigo = Codigo;
                jogo.Nome = Nome;
                jogo.Ano = Ano;
                jogo.IdMidia = IdMidia;
            }
            
            return jogo;
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Emprestimos;

namespace apiEmprestimoJogos.Models.ViewModel.Emprestimos
{
    public class UpdateEmprestimoViewModel
    {
        [Display(Name = "dataDevolucao"), Required (ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataDevolucao { get; set; }

        public Emprestimo MapTo(Emprestimo emprestimo)
        {
            if(emprestimo != null)
            {
                emprestimo.DataDevolucao = DataDevolucao;
            }

            return emprestimo;
        }
    }
}
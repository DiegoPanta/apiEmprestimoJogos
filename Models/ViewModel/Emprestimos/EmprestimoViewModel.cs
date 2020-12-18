using System;
using System.ComponentModel.DataAnnotations;
using apiEmprestimoJogos.Models.Entity.Emprestimos;

namespace apiEmprestimoJogos.Models.ViewModel.Emprestimos
{
    public class EmprestimoViewModel
    {
        [Display(Name = "idJogo"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdJogo { get; set; }

        [Display(Name = "idCliente"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int IdCliente { get; set; }

        [Display(Name = "codigoCliente"), Required (ErrorMessage = "Este campo é obrigatório")]
        public int CodigoCliente { get; set; }

        [Display(Name = "dataEmprestimo"), Required (ErrorMessage = "Este campo é obrigatório")]
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DevolucaoPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Emprestimo MapTo(Emprestimo emprestimo)
        {
            if(emprestimo != null){
                emprestimo.IdJogo = IdJogo;
                emprestimo.IdCliente = IdCliente;
                emprestimo.CodigoCliente = CodigoCliente;
                emprestimo.DataEmprestimo = DataEmprestimo;
                emprestimo.DevolucaoPrevista = DevolucaoPrevista;
                emprestimo.DataDevolucao = DataDevolucao;
            }
            
            return emprestimo;
        }
    }
}
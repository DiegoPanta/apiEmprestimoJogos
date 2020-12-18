using System;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Emprestimos
{
    public class EmprestimoJson : IActionResult
    {
        public EmprestimoJson(Emprestimo emprestimo)
        {
            Id = emprestimo.Id;
            JogoNome = emprestimo.Jogo.Nome;
            ClienteNome = emprestimo.Cliente.Nome;
            CodigoCliente = emprestimo.CodigoCliente;
            DataEmprestimo = emprestimo.DataEmprestimo;
            DevolucaoPrevista = emprestimo.DevolucaoPrevista;
            DataDevolucao = emprestimo.DataDevolucao;
        }

        public EmprestimoJson() { }

        public int Id { get; set; }
        public int CodigoCliente { get; set; }
        public string JogoNome { get; set; }
        public string ClienteNome { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DevolucaoPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
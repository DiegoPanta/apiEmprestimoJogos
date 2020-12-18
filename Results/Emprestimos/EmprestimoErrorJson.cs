using System.Threading.Tasks;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Emprestimos {
    public class EmprestimoErrorJson : IActionResult {
        EmprestimoGerenciamento _emprestimoGerenciamento;
        public EmprestimoErrorJson (EmprestimoGerenciamento emprestimoGerenciamento) {
            _emprestimoGerenciamento = emprestimoGerenciamento;
        }

        public async Task ExecuteResultAsync (ActionContext context) {
            if (_emprestimoGerenciamento.Emprestado) {
                await new UnprocessableEntityJson ("EMPRESTIMO_CADASTRADO").ExecuteResultAsync (context);
            } else if (_emprestimoGerenciamento.EmprestimoNaoEncontrado) {
                await new EmprestimoNaoEncontradoJson().ExecuteResultAsync (context);
            } else if (_emprestimoGerenciamento.JogoJaDevolvido) {
                await new UnprocessableEntityJson ("JOGO_JA_DEVOLVIDO").ExecuteResultAsync (context);
            } else if (_emprestimoGerenciamento.SemEmprestimosCadastrados) {
                await new SemCadastroEmprestimosJson().ExecuteResultAsync (context);
            }
        }
    }
}
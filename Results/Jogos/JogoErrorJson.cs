using System.Threading.Tasks;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Jogos {
    public class JogoErrorJson : IActionResult {
        JogoGerenciamento _jogoGerenciamento;

        public JogoErrorJson (JogoGerenciamento jogoGerenciamento) {
            _jogoGerenciamento = jogoGerenciamento;
        }

        public async Task ExecuteResultAsync (ActionContext context) {
            if (_jogoGerenciamento.JogoJaCadastrado) {
                await new UnprocessableEntityJson ("ESSE_JOGO_JA_FOI_CADASTRADO").ExecuteResultAsync (context);
            } else if (_jogoGerenciamento.JogoNaoEncontrado) {
                await new JogoNaoEncontradoJson().ExecuteResultAsync (context);
            } else if (_jogoGerenciamento.JogosNaoCadastrados) {
                await new JogosNaoCadastradosJson().ExecuteResultAsync (context);
            }
        }
    }
}
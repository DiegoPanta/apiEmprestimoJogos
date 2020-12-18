using System.Threading.Tasks;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Generos {
    public class GeneroErrorJson : IActionResult {
        GeneroGerenciamento _generoGerenciamento;
        public GeneroErrorJson (GeneroGerenciamento generoGerenciamento) {
            _generoGerenciamento = generoGerenciamento;
        }

        public async Task ExecuteResultAsync (ActionContext context) {
            if (_generoGerenciamento.GeneroJaCadastrado) {
                await new UnprocessableEntityJson ("ESSE_GENERO_JA_ESTA_CADASTRADO").ExecuteResultAsync (context);
            } else if (_generoGerenciamento.GeneroNaoEncontrado) {
                await new GeneroNaoEncontradoJson().ExecuteResultAsync (context);
            } else if (_generoGerenciamento.GenerosNaoCadastrados) {
                await new SemGenerosCadastradosJson().ExecuteResultAsync (context);
            }
        }
    }
}
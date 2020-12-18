using System.Threading.Tasks;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Tipos {
    public class TipoErrorJson : IActionResult {
        TipoGerenciamento _tipoGerenciamento;
        public TipoErrorJson (TipoGerenciamento tipoGerenciamento) {
            _tipoGerenciamento = tipoGerenciamento;
        }

        public async Task ExecuteResultAsync (ActionContext context) {
            if (_tipoGerenciamento.TipoJaExiste) {
                await new UnprocessableEntityJson ("ESSE_TIPO_JA_ESTA_CADASTRADO").ExecuteResultAsync (context);
            } else if (_tipoGerenciamento.TipoNaoEncontrado) {
                await new TipoNaoEncontradoJson().ExecuteResultAsync (context);
            } else if (_tipoGerenciamento.TiposNaoCadastrados) {
                await new TiposNaoCadastradosJson().ExecuteResultAsync (context);
            }
        }
    }
}
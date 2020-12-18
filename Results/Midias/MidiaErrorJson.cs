using System.Threading.Tasks;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Midias {
    public class MidiaErrorJson : IActionResult {
        MidiaGerenciamento _midiaGerenciamento;
        public MidiaErrorJson (MidiaGerenciamento midiaGerenciamento) {
            _midiaGerenciamento = midiaGerenciamento;
        }

        public async Task ExecuteResultAsync (ActionContext context) {
            if (_midiaGerenciamento.MidiaJaCadastrada) {
                await new UnprocessableEntityJson ("ESSA_MIDIA_JA_ESTA_CADASTRADA").ExecuteResultAsync (context);
            } else if (_midiaGerenciamento.MidiaNaoEncontrada) {
                await new MidiaNaoEncontradaJson ().ExecuteResultAsync (context);
            } else if (_midiaGerenciamento.MidiasNaoCadastradas) {
                await new MidiasNaoCadastradasJson().ExecuteResultAsync (context);
            }
        }
    }
}
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Clientes {
    public class ClienteErrorJson : IActionResult {
        private ClienteGerenciamento _clienteGerenciamento;

        public ClienteErrorJson (ClienteGerenciamento clienteGerenciamento) {
            _clienteGerenciamento = clienteGerenciamento;
        }

        public async Task ExecuteResultAsync (ActionContext context) {
            if (_clienteGerenciamento.ClienteCadastrado) {
                await new UnprocessableEntityJson("ESSE_CLIENTE_JA_ESTA_CADASTRADO").ExecuteResultAsync(context);
            } else if (_clienteGerenciamento.ClienteNaoEncontrado) {
                await new ClienteNaoEncontradoJson().ExecuteResultAsync(context);
            } else if (_clienteGerenciamento.SemClientesCadastros) {
                await new SemCadastroClientesJson().ExecuteResultAsync(context);
            }
        }
    }
}
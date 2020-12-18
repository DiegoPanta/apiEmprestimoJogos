using System.Threading.Tasks;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Usuarios {
    public class UsuarioErrorJson : IActionResult {
        UsuarioGerenciamento _usuarioGerenciamento;
        public UsuarioErrorJson (UsuarioGerenciamento usuarioGerenciamento) {
            _usuarioGerenciamento = usuarioGerenciamento;
        }

        public async Task ExecuteResultAsync (ActionContext context) {
            if (_usuarioGerenciamento.UsuarioNaoEncontrado) {
                await new UsuarioNaoEncontradoJson ().ExecuteResultAsync (context);
            } else if (_usuarioGerenciamento.UsuariosNaoCadastrados) {
                await new UsuariosNaoCadastradosJson ().ExecuteResultAsync (context);
            } else if (_usuarioGerenciamento.UsuarioCadastrado) {
                await new UnprocessableEntityJson ("USUARIO_CADASTRADO").ExecuteResultAsync (context);
            } else if (_usuarioGerenciamento.UsuarioNaoAutenticado) {
                await new UnprocessableEntityJson ("USUARIO_NAO_AUTENTICADO").ExecuteResultAsync (context);
            }
        }
    }
}
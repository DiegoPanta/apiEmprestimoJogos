using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Usuarios
{
    public class UsuarioNaoEncontradoJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("USUARIO_NAO_ENCONTRADO").ExecuteResultAsync(context);
        }
    }
}
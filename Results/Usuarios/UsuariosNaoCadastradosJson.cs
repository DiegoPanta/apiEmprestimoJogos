using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Usuarios
{
    public class UsuariosNaoCadastradosJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("USUARIOS_NAO_CADASTRADOS").ExecuteResultAsync(context);
        }
    }
}
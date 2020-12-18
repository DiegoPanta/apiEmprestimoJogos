using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Tokens
{
    public class CredenciaisInvalidaJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("CREDENCIAIS_INVALIDA").ExecuteResultAsync(context);
        }
    }
}
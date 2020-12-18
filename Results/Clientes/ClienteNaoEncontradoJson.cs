using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Clientes
{
    public class ClienteNaoEncontradoJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("CLIENTE_NAO_ENCONTRADO").ExecuteResultAsync(context);
        }
    }
}
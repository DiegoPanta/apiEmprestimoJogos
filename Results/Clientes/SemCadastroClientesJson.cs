using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Clientes
{
    public class SemCadastroClientesJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("SEM_CADASTRO_CLIENTES").ExecuteResultAsync(context);
        }
    }
}
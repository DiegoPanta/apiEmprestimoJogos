using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Tipos
{
    public class TipoNaoEncontradoJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("TIPO_NAO_ENCONTRADO").ExecuteResultAsync(context);
        }
    }
}
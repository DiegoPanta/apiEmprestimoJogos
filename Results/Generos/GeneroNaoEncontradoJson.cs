using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Generos
{
    public class GeneroNaoEncontradoJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("GENERO_NAO_ENCONTRADO").ExecuteResultAsync(context);
        }
    }
}
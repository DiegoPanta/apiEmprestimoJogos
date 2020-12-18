using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Generos
{
    public class SemGenerosCadastradosJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("GENEROS_NAO_CADASTRADOS").ExecuteResultAsync(context);
        }
    }
}
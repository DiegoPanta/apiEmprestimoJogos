using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Jogos
{
    public class JogosNaoCadastradosJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("JOGOS_NAO_CADASTRADOS").ExecuteResultAsync(context);
        }
    }
}
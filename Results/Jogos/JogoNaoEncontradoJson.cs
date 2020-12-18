using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Jogos
{
    public class JogoNaoEncontradoJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("JOGO_NAO_ENCONTRADO").ExecuteResultAsync(context);
        }
    }
}
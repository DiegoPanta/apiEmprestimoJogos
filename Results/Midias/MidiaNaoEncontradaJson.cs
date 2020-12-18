using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Midias
{
    public class MidiaNaoEncontradaJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("MIDIA_NAO_ENCONTRADA").ExecuteResultAsync(context);
        }
    }
}
using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Midias
{
    public class MidiasNaoCadastradasJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("MIDIAS_NAO_CADASTRADAS").ExecuteResultAsync(context);
        }
    }
}
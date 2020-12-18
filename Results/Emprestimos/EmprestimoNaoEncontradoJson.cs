using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Emprestimos {
    public class EmprestimoNaoEncontradoJson : IActionResult {
        public async Task ExecuteResultAsync (ActionContext context) {
            await new UnprocessableEntityJson ("EMPRESTIMO_NAO_ENCONTRADO").ExecuteResultAsync (context);
        }
    }
}
using System.Threading.Tasks;
using apiEmprestimoJogos.Results.Errors;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Emprestimos
{
    public class SemCadastroEmprestimosJson : IActionResult
    {
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new UnprocessableEntityJson("SEM_CADASTRO_EMPRESTIMOS").ExecuteResultAsync(context);
        }
    }
}
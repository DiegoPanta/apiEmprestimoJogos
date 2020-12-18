using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Emprestimos
{
    public class EmprestimoListJson : IActionResult
    {
        public EmprestimoListJson(ICollection<Emprestimo> emprestimos, long count)
        {
            Emprestimos = emprestimos.Select(item => new EmprestimoJson(item)).ToList();
            Count = count;
        }

        public ICollection<EmprestimoJson> Emprestimos{ get; set; }
        public long Count { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
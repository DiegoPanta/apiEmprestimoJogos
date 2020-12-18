using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Midias;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Midias
{
    public class MidiaListJson : IActionResult
    {
        public MidiaListJson(ICollection<Midia> midias, long count)
        {
            Midias = midias.Select(item => new MidiaJson(item)).ToList();
            Count = count;
        }

        public ICollection<MidiaJson> Midias{ get; set; }
        public long Count { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
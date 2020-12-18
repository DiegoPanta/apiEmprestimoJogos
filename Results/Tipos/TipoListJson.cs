using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Tipos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Tipos {
    public class TipoListJson : IActionResult {
        public TipoListJson (ICollection<Tipo> tipos, long count) {
            Tipos = tipos.Select (item => new TipoJson (item)).ToList ();
            Count = count;
        }

        public ICollection<TipoJson> Tipos { get; set; }
        public long Count { get; set; }

        public async Task ExecuteResultAsync (ActionContext context) {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
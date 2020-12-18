using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Jogos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Jogos
{
    public class JogoListJson : IActionResult
    {
        public JogoListJson(ICollection<Jogo> jogos, long count)
        {
            Jogos = jogos.Select(item => new JogoJson(item)).ToList();
            Count = count;
        }

        public ICollection<JogoJson> Jogos{ get; set;}
        public long Count { get; set; }
       
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
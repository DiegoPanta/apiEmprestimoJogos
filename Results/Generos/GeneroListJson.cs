using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Generos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Generos
{
    public class GeneroListJson : IActionResult
    {
        public GeneroListJson(ICollection<Genero> generos, long count){
            Generos = generos.Select(item => new GeneroJson(item)).ToList();
            Count = count;
        }

        public ICollection<GeneroJson> Generos { get; set; }
        public long Count { get; set; }
        
        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
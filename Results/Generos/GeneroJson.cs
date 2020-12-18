using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Generos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Generos
{
    public class GeneroJson : IActionResult
    {
        public GeneroJson(Genero genero)
        {
            Id = genero.Id;
            Descricao = genero.Descricao;
        }

        public GeneroJson() { }
        
        public int Id { get; set; }
        public string Descricao { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
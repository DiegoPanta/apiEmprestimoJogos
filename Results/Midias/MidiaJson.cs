using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Midias;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Midias
{
    public class MidiaJson : IActionResult
    {
        public MidiaJson(Midia midia)
        {
            Id = midia.Id;
            Descricao = midia.Descricao;
        }

        public MidiaJson(){ }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
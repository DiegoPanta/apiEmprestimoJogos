using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Tipos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Tipos
{
    public class TipoJson : IActionResult
    {
        public TipoJson(Tipo tipo)
        {
            Id = tipo.Id;
            Descricao = tipo.Descricao;
        }

        public TipoJson() { }

        public int Id { get; set; }
        public string Descricao{ get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
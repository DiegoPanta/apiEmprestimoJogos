using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Clientes
{
    public class ClienteJson : IActionResult
    {
        public ClienteJson(Cliente cliente)
        {
            Id = cliente.Id;
            Nome = cliente.Nome;
            Codigo = cliente.Codigo;
            Telefone = cliente.Telefone;
        }

        public ClienteJson() { }

            public int Id { get; set; }
            public string Nome { get; set; }
            public int Codigo { get; set; }
            public string Telefone { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
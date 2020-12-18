using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Clientes
{
    public class ClienteListJson : IActionResult
    {
        public ClienteListJson(ICollection<Cliente> clientes, long count)
        {
            Clientes = clientes.Select(item => new ClienteJson(item)).ToList();
            Count = count;
        }

        public ICollection<ClienteJson> Clientes{ get; set; }
        public long Count { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Usuarios
{
    public class UsuarioListJson : IActionResult
    {
        public UsuarioListJson(ICollection<Usuario> usuarios, long count){
            Usuarios = usuarios.Select(item => new UsuarioJson(item)).ToList();
            Count = count;
        }

        public ICollection<UsuarioJson> Usuarios { get; set; }
        public long Count { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
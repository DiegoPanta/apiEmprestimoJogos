using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Usuarios {
    public class UsuarioJson : IActionResult {
        public UsuarioJson (Usuario usuario) {
            Codigo = usuario.Codigo;
            Senha = usuario.Senha;
        }

        public UsuarioJson () { }

        public string Codigo { get; set; }
        public string Senha { get; set; }

        public async Task ExecuteResultAsync (ActionContext context) {
            await new JsonResult (this).ExecuteResultAsync (context);
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Usuarios;
using apiEmprestimoJogos.Results.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Controllers {
    
    [Route ("api/usuarios")]
    public class UsuariosController : EmprestimoJogosBaseController {
        private IServiceProvider _provider;

        public UsuariosController (IServiceProvider provider) {
            _provider = provider;
        }
        [HttpGet, Route ("{id:long}")]
        public async Task<IActionResult> GetById ([FromRoute] long id) {
            var usuarioGerenciamento = _provider.GetRequiredService<UsuarioGerenciamento> ();
            await usuarioGerenciamento.GetById (id);

            if(usuarioGerenciamento.Usuario == null)
            {
                return new UsuarioNaoEncontradoJson();
            }

            return new UsuarioJson (usuarioGerenciamento.Usuario);
        }

        [HttpGet, Route ("")]
        public async Task<IActionResult> GetAll () {
            var usuarioGerenciamento = _provider.GetRequiredService<UsuarioGerenciamento> ();
            await usuarioGerenciamento.GetAll ();
            
            if(!usuarioGerenciamento.Usuarios.Any())
            {
                return new UsuariosNaoCadastradosJson();
            }

            var count = usuarioGerenciamento.Usuarios.LongCount ();
            return new UsuarioListJson (usuarioGerenciamento.Usuarios, count);
        }

        [AllowAnonymous]
        [HttpPost, Route ("autenticar")]
        public async Task<IActionResult> Autenticar ([FromBody] UsuarioViewModel viewModel) {
            var usuarioGerenciamento = _provider.GetRequiredService<UsuarioGerenciamento> ();

            if (!await usuarioGerenciamento.Autenticar (viewModel.MapTo (new Usuario ()))) {
                return new UsuarioErrorJson (usuarioGerenciamento);
            }

            return new UsuarioJson (usuarioGerenciamento.Usuario);
        }

        [HttpPost, Route ("")]
        public async Task<IActionResult> Post ([FromBody] UsuarioViewModel viewModel) {
            var usuarioGerenciamento = _provider.GetRequiredService<UsuarioGerenciamento> ();

            if (!await usuarioGerenciamento.Insert (viewModel.MapTo (new Usuario ()))) {
                return new UsuarioErrorJson (usuarioGerenciamento);
            }

            return Created ();
        }

        [HttpPut, Route ("{id:long}")]
        public async Task<IActionResult> Put ([FromRoute] long id, [FromBody] UsuarioViewModel viewModel) {
            var usuarioGerenciamento = _provider.GetRequiredService<UsuarioGerenciamento> ();
            await usuarioGerenciamento.GetById (id);
            viewModel.MapTo (usuarioGerenciamento.Usuario);

            if (!await usuarioGerenciamento.Update ()) {
                return new UsuarioErrorJson (usuarioGerenciamento);
            }

            return new UsuarioJson (usuarioGerenciamento.Usuario);
        }

        [HttpDelete, Route ("{id:long}")]
        public async Task<IActionResult> Delete ([FromRoute] long id) {
            var usuarioGerenciamento = _provider.GetRequiredService<UsuarioGerenciamento> ();
            await usuarioGerenciamento.GetById (id);

            if(usuarioGerenciamento.Usuario == null)
            {
                return new UsuarioNaoEncontradoJson();
            }

            if (!await usuarioGerenciamento.Delete ()) {
                return new UsuarioErrorJson (usuarioGerenciamento);
            }

            return new UsuarioJson (usuarioGerenciamento.Usuario);
        }
    }
}
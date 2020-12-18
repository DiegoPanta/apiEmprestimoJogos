using System;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Generos;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Generos;
using apiEmprestimoJogos.Results.Generos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Controllers {
    [Route ("api/generos")]
    public class GenerosController : EmprestimoJogosBaseController {
        private IServiceProvider _provider;

        public GenerosController (IServiceProvider provider) {
            _provider = provider;
        }

        [HttpGet, Route ("{id:long}")]
        public async Task<IActionResult> GetById ([FromRoute] long id) {
            var generoGerenciamento = _provider.GetRequiredService<GeneroGerenciamento> ();
            await generoGerenciamento.GetById (id);

            if(generoGerenciamento.Genero == null)
            {
                return new GeneroNaoEncontradoJson();
            }

            return new GeneroJson (generoGerenciamento.Genero);
        }

        [HttpGet, Route ("")]
        public async Task<IActionResult> GetAll () {
            var generoGerenciamento = _provider.GetRequiredService<GeneroGerenciamento> ();
            await generoGerenciamento.GetAll ();

            if(!generoGerenciamento.Generos.Any())
            {
                return new SemGenerosCadastradosJson();
            }

            var count = generoGerenciamento.Generos.LongCount ();

            return new GeneroListJson (generoGerenciamento.Generos, count);
        }

        [HttpPost, Route ("")]
        public async Task<IActionResult> Post ([FromBody] GeneroViewModel viewModel) {
            var generoGerenciamento = _provider.GetRequiredService<GeneroGerenciamento> ();

            if (!await generoGerenciamento.Insert (viewModel.MapTo (new Genero ()))) {
                return new GeneroErrorJson (generoGerenciamento);
            }

            return Created ();
        }

        [HttpDelete, Route ("{id:long}")]
        public async Task<IActionResult> Delete ([FromRoute] int id) {
            var generoGerenciamento = _provider.GetRequiredService<GeneroGerenciamento> ();
            await generoGerenciamento.GetById (id);

            if(generoGerenciamento.Genero == null)
            {
                return new GeneroNaoEncontradoJson();
            }

            if (!await generoGerenciamento.Delete ()) {
                return new GeneroErrorJson (generoGerenciamento);
            }

            return new GeneroJson (generoGerenciamento.Genero);
        }
    }
}
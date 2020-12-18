using System;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Midias;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Midias;
using apiEmprestimoJogos.Results.Midias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Controllers
{
    [Route("api/midias")]
    public class MidiasController : EmprestimoJogosBaseController
    {
        private IServiceProvider _provider;

        public MidiasController (IServiceProvider provider) {
            _provider = provider;
        }

        [HttpGet, Route ("{id:long}")]
        public async Task<IActionResult> GetById ([FromRoute] long id) {
            var midiaGerenciamento = _provider.GetRequiredService<MidiaGerenciamento> ();
            await midiaGerenciamento.GetById (id);
            
            if(midiaGerenciamento.Midia == null)
            {
                return new MidiaNaoEncontradaJson();
            }

            return new MidiaJson (midiaGerenciamento.Midia);
        }

        [HttpGet, Route ("")]
        public async Task<IActionResult> GetAll () {
            var midiaGerenciamento = _provider.GetRequiredService<MidiaGerenciamento> ();
            await midiaGerenciamento.GetAll ();

            if(!midiaGerenciamento.Midias.Any())
            {
                return new MidiasNaoCadastradasJson();
            }

            var count = midiaGerenciamento.Midias.LongCount ();

            return new MidiaListJson (midiaGerenciamento.Midias, count);
        }

        [HttpPost, Route ("")]
        public async Task<IActionResult> Post ([FromBody] MidiaViewModel viewModel) {
            var midiaGerenciamento = _provider.GetRequiredService<MidiaGerenciamento> ();

            if (!await midiaGerenciamento.Insert (viewModel.MapTo (new Midia ()))) {
                return new MidiaErrorJson (midiaGerenciamento);
            }

            return Created ();
        }

        [HttpDelete, Route ("{id:long}")]
        public async Task<IActionResult> Delete ([FromRoute] int id) {
            var midiaGerenciamento = _provider.GetRequiredService<MidiaGerenciamento> ();
            await midiaGerenciamento.GetById (id);

            if(midiaGerenciamento.Midia == null)
            {
                return new MidiaNaoEncontradaJson();
            }

            if (!await midiaGerenciamento.Delete ()) {
                return new MidiaErrorJson (midiaGerenciamento);
            }

            return new MidiaJson (midiaGerenciamento.Midia);
        }
    }
}
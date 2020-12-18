using System;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Tipos;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Tipos;
using apiEmprestimoJogos.Results.Tipos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Controllers {

    [Route ("api/tipos")]
    public class TiposController : EmprestimoJogosBaseController {
        private IServiceProvider _provider;

        public TiposController (IServiceProvider provider) 
        {
            _provider = provider;
        }

        [HttpGet, Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var tipoGerenciamento = _provider.GetRequiredService<TipoGerenciamento>();
            await tipoGerenciamento.GetById(id);

            if(tipoGerenciamento.Tipo == null)
            {
                return new TipoNaoEncontradoJson();
            }

            return new TipoJson(tipoGerenciamento.Tipo);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAll()
        {
            var tipoGerenciamento = _provider.GetRequiredService<TipoGerenciamento>();
            await tipoGerenciamento.GetAll();

            if(!tipoGerenciamento.Tipos.Any())
            {
                return new TiposNaoCadastradosJson();
            }

            var count = tipoGerenciamento.Tipos.LongCount();

            return new TipoListJson(tipoGerenciamento.Tipos, count);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] TipoViewModel viewModel)
        {
            var tipoGerenciamento = _provider.GetRequiredService<TipoGerenciamento>();

            if(! await tipoGerenciamento.Insert(viewModel.MapTo(new Tipo()))){
                return new TipoErrorJson(tipoGerenciamento);
            }

            return Created();
        }

        [HttpDelete, Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tipoGerenciamento = _provider.GetRequiredService<TipoGerenciamento>();
            await tipoGerenciamento.GetById(id);

            if(tipoGerenciamento.Tipo == null)
            {
                return new TipoNaoEncontradoJson();
            }

            if(! await tipoGerenciamento.Delete())
            {
                return new TipoErrorJson(tipoGerenciamento);
            }

            return new TipoJson(tipoGerenciamento.Tipo);
        }
    }
}
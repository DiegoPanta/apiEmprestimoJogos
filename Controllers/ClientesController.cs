using System;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Clientes;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Clientes;
using apiEmprestimoJogos.Results.Clientes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Controllers {

    [Route ("api/clientes")]
    public class ClientesController : EmprestimoJogosBaseController {
        private IServiceProvider _provider;

        public ClientesController (IServiceProvider provider) {
            _provider = provider;
        }

        [HttpGet, Route ("{id:long}")]
        public async Task<IActionResult> GetById ([FromRoute] long id) {
            var clienteGerenciamento = _provider.GetRequiredService<ClienteGerenciamento> ();
            await clienteGerenciamento.GetById (id);

            if(clienteGerenciamento.Cliente == null)
            {
                return new ClienteNaoEncontradoJson();
            }

            return new ClienteJson (clienteGerenciamento.Cliente);
        }

        [HttpGet, Route ("")]
        public async Task<IActionResult> GetAll () {
            var clienteGerenciamento = _provider.GetRequiredService<ClienteGerenciamento> ();
            await clienteGerenciamento.GetAll ();

            if(!clienteGerenciamento.Clientes.Any())
            {
                return new SemCadastroClientesJson();
            }

            var count = clienteGerenciamento.Clientes.LongCount ();

            return new ClienteListJson (clienteGerenciamento.Clientes, count);
        }

        [HttpPost, Route ("")]
        public async Task<IActionResult> Post ([FromBody] ClienteViewModel viewModel) {
            var clienteGerenciamento = _provider.GetRequiredService<ClienteGerenciamento> ();

            if(! await clienteGerenciamento.Insert(viewModel.MapTo(new Cliente())))
            {
                return new ClienteErrorJson(clienteGerenciamento);
            }

            return Created ();
        }

        [HttpPut, Route ("{id:long}")]
        public async Task<IActionResult> Put ([FromRoute] long id, [FromBody] ClienteViewModel viewModel) {
            var clienteGerenciamento = _provider.GetRequiredService<ClienteGerenciamento> ();
            
            await clienteGerenciamento.GetById(id);

            viewModel.MapTo(clienteGerenciamento.Cliente);

            if(!await clienteGerenciamento.Update())
            {
                return new ClienteErrorJson(clienteGerenciamento);
            }
            
            return new ClienteJson (clienteGerenciamento.Cliente);
        }

        [HttpDelete, Route ("{id:long}")]
        public async Task<IActionResult> Delete ([FromRoute] int id) {
            var clienteGerenciamento = _provider.GetRequiredService<ClienteGerenciamento> ();
            await clienteGerenciamento.GetById (id);

            if(clienteGerenciamento.Cliente == null)
            {
                return new ClienteNaoEncontradoJson();
            }

            if(!await clienteGerenciamento.Delete())
            {
                return new ClienteErrorJson(clienteGerenciamento);
            }

            return new ClienteJson (clienteGerenciamento.Cliente);
        }
    }
}
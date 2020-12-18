using System;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Emprestimos;
using apiEmprestimoJogos.Results.Emprestimos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Controllers {

    [Route ("api/emprestimos")]
    public class EmprestimosController : EmprestimoJogosBaseController {
        private IServiceProvider _provider;

        public EmprestimosController (IServiceProvider provider) {
            _provider = provider;
        }

        [HttpGet, Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var emprestimoGerenciamento = _provider.GetRequiredService<EmprestimoGerenciamento>();
            await emprestimoGerenciamento.GetById(id);
            
            if(emprestimoGerenciamento.Emprestimo == null)
            {
                return new EmprestimoNaoEncontradoJson();
            }

            return new EmprestimoJson(emprestimoGerenciamento.Emprestimo);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAll()
        {
            var emprestimoGerenciamento = _provider.GetRequiredService<EmprestimoGerenciamento>();
            await emprestimoGerenciamento.GetAll();

            if(!emprestimoGerenciamento.Emprestimos.Any())
            {
                return new SemCadastroEmprestimosJson();
            }

            var count = emprestimoGerenciamento.Emprestimos.LongCount();

            return new EmprestimoListJson(emprestimoGerenciamento.Emprestimos, count);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] EmprestimoViewModel viewModel)
        {
            var emprestimoGerenciamento = _provider.GetRequiredService<EmprestimoGerenciamento>();

            if(! await emprestimoGerenciamento.Insert(viewModel.MapTo(new Emprestimo())))
            {
                return new EmprestimoErrorJson(emprestimoGerenciamento);
            }

            return Created();
        }
        
        [HttpPut, Route("{id:long}")]
        public async Task<IActionResult> Devolucao([FromRoute] long id, [FromBody] UpdateEmprestimoViewModel viewModel)
        {
            var emprestimoGerenciamento = _provider.GetRequiredService<EmprestimoGerenciamento>();

            await emprestimoGerenciamento.GetById(id);
            
            if(emprestimoGerenciamento.Emprestimo == null)
            {
                return new EmprestimoNaoEncontradoJson();
            }

            viewModel.MapTo(emprestimoGerenciamento.Emprestimo);

            if(!await emprestimoGerenciamento.Devolucao())
            {
                return new EmprestimoErrorJson(emprestimoGerenciamento);
            }

            return new EmprestimoJson(emprestimoGerenciamento.Emprestimo);
        }

        [HttpDelete, Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var emprestimoGerenciamento = _provider.GetRequiredService<EmprestimoGerenciamento>();
            await emprestimoGerenciamento.GetById(id);

            if(emprestimoGerenciamento.Emprestimo == null)
            {
                return new EmprestimoNaoEncontradoJson();
            }

            if(! await emprestimoGerenciamento.Delete())
            {
                return new EmprestimoErrorJson(emprestimoGerenciamento);
            }
            
            return new EmprestimoJson(emprestimoGerenciamento.Emprestimo);
        }
    }
}
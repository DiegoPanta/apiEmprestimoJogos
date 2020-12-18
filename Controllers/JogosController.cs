using System;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Jogos;
using apiEmprestimoJogos.Models.ServiceModel;
using apiEmprestimoJogos.Models.ViewModel.Jogos;
using apiEmprestimoJogos.Results.Jogos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Controllers
{
    [Route ("api/jogos")]
    public class JogosController : EmprestimoJogosBaseController
    {
        private IServiceProvider _provider;

        public JogosController (IServiceProvider provider) 
        {
            _provider = provider;
        }

        [HttpGet, Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var jogoGerenciamento = _provider.GetRequiredService<JogoGerenciamento>();
            await jogoGerenciamento.GetById(id);

            if(jogoGerenciamento.Jogo == null)
            {
                return new JogoNaoEncontradoJson();
            }

            return new JogoJson(jogoGerenciamento.Jogo);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAll()
        {
            var jogoGerenciamento = _provider.GetRequiredService<JogoGerenciamento>();
            await jogoGerenciamento.GetAll();

            if(!jogoGerenciamento.Jogos.Any()){
                return new JogosNaoCadastradosJson();
            }

            var count = jogoGerenciamento.Jogos.LongCount();

            return new JogoListJson(jogoGerenciamento.Jogos, count);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] JogoViewModel viewModel)
        {
            var jogoGerenciamento = _provider.GetRequiredService<JogoGerenciamento>();

            if(! await jogoGerenciamento.Insert(viewModel.MapTo(new Jogo()))){
                return new JogoErrorJson(jogoGerenciamento);
            }

            return Created();
        }

        [HttpPut, Route("{id:long}")]
        public async Task<IActionResult> Put([FromRoute] long id, [FromBody] JogoViewModel viewModel)
        {
            var jogoGerenciamento = _provider.GetRequiredService<JogoGerenciamento>();

            await jogoGerenciamento.GetById(id);
            viewModel.MapTo(jogoGerenciamento.Jogo);

            if(!await jogoGerenciamento.Update())
            {
                return new JogoErrorJson(jogoGerenciamento);
            }

            return new JogoJson(jogoGerenciamento.Jogo);
        }

        [HttpDelete, Route("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var jogoGerenciamento = _provider.GetRequiredService<JogoGerenciamento>();
            await jogoGerenciamento.GetById(id);

            if(jogoGerenciamento.Jogo == null)
            {
                return new JogoNaoEncontradoJson();
            }

            if(!await jogoGerenciamento.Delete())
            {
                return new JogoErrorJson(jogoGerenciamento);
            }

            return new JogoJson(jogoGerenciamento.Jogo);
        }
    }
}
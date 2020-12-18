using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Jogos;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Results.Jogos {
    public class JogoJson : IActionResult {
        public JogoJson (Jogo jogo) {
            Id = jogo.Id;
            TipoDescricao = jogo.Tipo.Descricao;
            MidiaDescricao = jogo.Midia.Descricao;
            GeneroDescricao = jogo.Genero.Descricao;
            Codigo = jogo.Codigo;
            Nome = jogo.Nome;
            Ano = jogo.Ano;
        }

        public JogoJson () { }

        public int Id { get; set; }
        public string TipoDescricao { get; set; }
        public string MidiaDescricao { get; set; }
        public string GeneroDescricao { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }

        public async Task ExecuteResultAsync (ActionContext context) {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
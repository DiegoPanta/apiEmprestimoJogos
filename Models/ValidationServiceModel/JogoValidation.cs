using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Jogos;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.ValidationServiceModel
{
    public class JogoValidation
    {
        private ApiDbContext _dbContext;

        public JogoValidation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> JogoCadastrado(Jogo jogo)
        {
            return await _dbContext.Jogos
                .WhereAnotherId(jogo.Id)
                .WhereCodigo(jogo.Codigo)
                .AnyAsync();
        }

        public bool JogoNaoEncontrado(Jogo jogo)
        {
            return jogo == null;
        }
    }
}
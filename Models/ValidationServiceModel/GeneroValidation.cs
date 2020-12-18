using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Generos;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.ValidationServiceModel
{
    public class GeneroValidation
    {
        private ApiDbContext _dbContext;

        public GeneroValidation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> GeneroCadastrado(Genero genero)
        {
            return await _dbContext.Generos
                .WhereDescricao(genero.Descricao)
                .AnyAsync();
        }

        public bool GeneroNaoEncontrado(Genero genero)
        {
            return genero == null;
        }
    }
}
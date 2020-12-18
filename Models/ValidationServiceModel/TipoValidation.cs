using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Tipos;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.ValidationServiceModel
{
    public class TipoValidation
    {
        private ApiDbContext _dbContext;

        public TipoValidation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> TipoCadastrado(Tipo tipo)
        {
            return await _dbContext.Tipos
                .WhereDescricao(tipo.Descricao)
                .AnyAsync();
        }

        public bool TipoNaoEncontrado(Tipo tipo)
        {
            return tipo == null;
        }
    }
}
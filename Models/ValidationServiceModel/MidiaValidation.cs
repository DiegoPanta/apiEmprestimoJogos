using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Midias;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.ValidationServiceModel
{
    public class MidiaValidation
    {
        private ApiDbContext _dbContext;

        public MidiaValidation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> MidiaCadastrada(Midia midia)
        {
            return await _dbContext.Midias
                .WhereDescricao(midia.Descricao)
                .AnyAsync();
        }

        public bool MidiaNaoEncontrada(Midia midia)
        {
            return midia == null;
        }
    }
}
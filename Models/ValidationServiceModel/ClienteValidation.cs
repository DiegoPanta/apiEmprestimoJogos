using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Clientes;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.ValidationServiceModel
{
    public class ClienteValidation
    {
        private ApiDbContext _dbContext;

        public ClienteValidation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ClienteCadastrado(Cliente cliente)
        {
            return await _dbContext.Clientes
                .WhereAnotherId(cliente.Id)
                .WhereCodigo(cliente.Codigo)
                .AnyAsync();
        }

        public bool ClienteNaoEncontrado(Cliente cliente)
        {
            return cliente == null;
        }
    }
}
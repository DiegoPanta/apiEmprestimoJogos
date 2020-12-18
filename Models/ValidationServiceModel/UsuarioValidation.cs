using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.ValidationServiceModel {
    public class UsuarioValidation {
        private ApiDbContext _dbContext;

        public UsuarioValidation (ApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<bool> UsuarioCadastrado(Usuario usuario)
        {
            return await _dbContext.Usuarios
                .WhereUsuario(usuario.Codigo)
                .WhereSenha(usuario.Senha)
                .AnyAsync();
        }

        public bool UsuarioNaoEncontrado(Usuario usuario)
        {
            return usuario == null;
        }

    }
}
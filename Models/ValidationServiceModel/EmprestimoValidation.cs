using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.ValidationServiceModel {
    public class EmprestimoValidation {
        private ApiDbContext _dbContext;

        public EmprestimoValidation(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmprestimoCadastrado(Emprestimo emprestimo)
        {
            return await _dbContext.Emprestimos
                .WhereById(emprestimo.Id)
                .AnyAsync();
        }

        public async Task<bool> JogoJaDevolvido(Emprestimo emprestimo)
        {
            return await _dbContext.Emprestimos
                .WhereById(emprestimo.Id)
                .WhereDevolucao()
                .AnyAsync();
        }

        public bool EmprestimoNaoEncontrado(Emprestimo emprestimo)
        {
            return emprestimo == null;
        }
    }
}
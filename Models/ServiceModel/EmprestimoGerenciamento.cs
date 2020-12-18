using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Models.ServiceModel {
    public class EmprestimoGerenciamento {
        private ApiDbContext _dbContext;
        private IServiceProvider _provider;

        public Emprestimo Emprestimo { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }
        public bool EmprestimoNaoEncontrado { get; set; }
        public bool Emprestado { get; set; }
        public bool SemEmprestimosCadastrados { get; set; }
        public bool JogoJaDevolvido { get; set; }

        public EmprestimoGerenciamento (ApiDbContext dbContext, IServiceProvider provider) {
            _dbContext = dbContext;
            _provider = provider;
        }

        public async Task GetById (long id) {
            var emprestimoValidation = _provider.GetRequiredService<EmprestimoValidation>();

            Emprestimo = await _dbContext.Emprestimos
                .Include(p => p.Cliente)
                .Include(p => p.Jogo)
                .WhereById (id)
                .SingleOrDefaultAsync ();

            EmprestimoNaoEncontrado = emprestimoValidation.EmprestimoNaoEncontrado(Emprestimo);
            if(EmprestimoNaoEncontrado) return;
        }

        public async Task GetAll () {
            Emprestimos = await _dbContext.Emprestimos
                .Include(p => p.Cliente)
                .Include(p => p.Jogo)
                .ToListAsync ();

            SemEmprestimosCadastrados = !Emprestimos.Any();
        }

        public async Task<bool> Insert (Emprestimo emprestimo) {
            var emprestimoValidation = _provider.GetRequiredService<EmprestimoValidation>();
            
            Emprestimo = emprestimo;

            Emprestado = await emprestimoValidation.EmprestimoCadastrado(Emprestimo);

            if (Emprestado) return false;

            _dbContext.Emprestimos.Add (Emprestimo);
            await _dbContext.SaveChangesAsync ();

            return true;
        }

        public async Task<bool> Devolucao () {
            var emprestimoValidation = _provider.GetRequiredService<EmprestimoValidation>();
            
            if (Emprestado) return false;
            
            JogoJaDevolvido = await emprestimoValidation.JogoJaDevolvido(Emprestimo);

            await _dbContext.SaveChangesAsync ();

            return true;
        }

        public async Task<bool> Delete () {
            if (EmprestimoNaoEncontrado) return false;

            _dbContext.Emprestimos.Remove (Emprestimo);
            await _dbContext.SaveChangesAsync ();

            return true;
        }
    }
}
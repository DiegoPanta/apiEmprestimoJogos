using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Jogos;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Models.ServiceModel {
    public class JogoGerenciamento {
        private ApiDbContext _dbContext;
        private IServiceProvider _provider;

        public Jogo Jogo  { get; private set; }
        public ICollection<Jogo> Jogos { get; private set; }
        public bool JogoJaCadastrado { get; set; }
        public bool JogoNaoEncontrado { get; set; }
        public bool JogosNaoCadastrados { get; set; }

        public JogoGerenciamento (ApiDbContext dbContext, IServiceProvider provider) {
            _dbContext = dbContext;
            _provider = provider;
        }

        public async Task GetById(long id)
        {
            var jogoValidation = _provider.GetRequiredService<JogoValidation>();

            Jogo = await _dbContext.Jogos
                .Include(p => p.Tipo)
                .Include(p => p.Midia)
                .Include(p => p.Genero)
                .WhereById(id)
                .SingleOrDefaultAsync();

            JogoNaoEncontrado = jogoValidation.JogoNaoEncontrado(Jogo);
            if(JogoNaoEncontrado) return;
        }

        public async Task GetAll()
        {
            Jogos = await _dbContext.Jogos
                .Include(p => p.Tipo)
                .Include(p => p.Midia)
                .Include(p => p.Genero)
                .ToListAsync();

            JogosNaoCadastrados = !Jogos.Any();
        }

        public async Task<bool> Insert(Jogo jogo)
        {
            var jogoValidation = _provider.GetRequiredService<JogoValidation>();

            Jogo = jogo;

            JogoJaCadastrado = await jogoValidation.JogoCadastrado(Jogo);
            if(JogoJaCadastrado) return false;
            
            _dbContext.Jogos.Add(Jogo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update()
        {
            var jogoValidation = _provider.GetRequiredService<JogoValidation>();

            if(JogoNaoEncontrado) return false;

            JogoJaCadastrado = await jogoValidation.JogoCadastrado(Jogo);
            if(JogoJaCadastrado) return false;

            await _dbContext.SaveChangesAsync();

            return true;
        }
        
        public async Task<bool> Delete()
        {
            if(JogoNaoEncontrado) return false;

            _dbContext.Jogos.Remove(Jogo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
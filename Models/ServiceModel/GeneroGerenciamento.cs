using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Generos;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Models.ServiceModel {
    public class GeneroGerenciamento {
        private ApiDbContext _dbContext;
        private IServiceProvider _provider;

        public Genero Genero { get; private set; }
        public ICollection<Genero> Generos { get; set; }
        public bool GeneroJaCadastrado { get; set; }
        public bool GeneroNaoEncontrado { get; set; }
        public bool GenerosNaoCadastrados { get; set; }

        public GeneroGerenciamento (ApiDbContext dbContext, IServiceProvider provider) {
            _dbContext = dbContext;
            _provider = provider;
        }

        public async Task GetById(long id)
        {
            var generoValidation = _provider.GetRequiredService<GeneroValidation>();

            Genero = await _dbContext.Generos
                .WhereById(id)
                .SingleOrDefaultAsync();
            
            GeneroNaoEncontrado = generoValidation.GeneroNaoEncontrado(Genero);
            if(GeneroNaoEncontrado) return;
        }

        public async Task GetAll()
        {
            Generos = await _dbContext.Generos
                .ToListAsync();
            
            GenerosNaoCadastrados = !Generos.Any();
        }

        public async Task<bool> Insert(Genero genero)
        {
            var generoValidation = _provider.GetRequiredService<GeneroValidation>();

            Genero = genero;

            GeneroJaCadastrado = await generoValidation.GeneroCadastrado(Genero);
            if(GeneroJaCadastrado) return false;

            _dbContext.Generos.Add(Genero);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete()
        {
            if(GeneroNaoEncontrado) return false;

            _dbContext.Generos.Remove(Genero);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Midias;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Models.ServiceModel {
    public class MidiaGerenciamento {
        private ApiDbContext _dbContext;
        private IServiceProvider _provider;

        public Midia Midia { get; private set; }
        public ICollection<Midia> Midias { get; set; }
        public bool MidiaJaCadastrada { get; set; }
        public bool MidiaNaoEncontrada { get; set; }
        public bool MidiasNaoCadastradas { get; set; }

        public MidiaGerenciamento (ApiDbContext dbContext, IServiceProvider provider) {
            _dbContext = dbContext;
            _provider = provider;
        }

        public async Task GetById(long id)
        {
            var midiaValidation = _provider.GetRequiredService<MidiaValidation>();

            Midia = await _dbContext.Midias
                .WhereById(id)
                .SingleOrDefaultAsync();
            
            MidiaNaoEncontrada = midiaValidation.MidiaNaoEncontrada(Midia);
            if(MidiaNaoEncontrada) return;
        }

        public async Task GetAll()
        {
            Midias = await _dbContext.Midias
                .ToListAsync();

            MidiasNaoCadastradas = !Midias.Any();
        }

        public async Task<bool> Insert(Midia midia)
        {
            var midiaValidation = _provider.GetRequiredService<MidiaValidation>();

            Midia = midia;

            MidiaJaCadastrada = await midiaValidation.MidiaCadastrada(Midia);
            if(MidiaJaCadastrada) return false;

            _dbContext.Midias.Add(Midia);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete()
        {
            if(MidiaNaoEncontrada) return false;

            _dbContext.Midias.Remove(Midia);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
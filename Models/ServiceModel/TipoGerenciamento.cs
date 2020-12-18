using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Tipos;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Models.ServiceModel {
    public class TipoGerenciamento {
        private ApiDbContext _dbContext;
        private IServiceProvider _provider;

        public Tipo Tipo { get; private set; }
        public ICollection<Tipo> Tipos { get; set; }
        public bool TipoJaExiste { get; set; }
        public bool TipoNaoEncontrado { get; set; }
        public bool TiposNaoCadastrados { get; set; }

        public TipoGerenciamento (ApiDbContext dbContext, IServiceProvider provider) {
            _dbContext = dbContext;
            _provider = provider;
        }

        public async Task GetById (long id) {

            var tipoValidation = _provider.GetRequiredService<TipoValidation> ();

            Tipo = await _dbContext.Tipos
                .WhereById (id)
                .SingleOrDefaultAsync ();

            TipoNaoEncontrado = tipoValidation.TipoNaoEncontrado(Tipo);
            if (TipoNaoEncontrado) return;
        }

        public async Task GetAll () {
            Tipos = await _dbContext.Tipos
                .ToListAsync ();
            
            TiposNaoCadastrados = !Tipos.Any();
        }

        public async Task<bool> Insert (Tipo tipo) {
            var tipoValidation = _provider.GetRequiredService<TipoValidation> ();

            Tipo = tipo;

            TipoJaExiste = await tipoValidation.TipoCadastrado(Tipo);
            if (TipoJaExiste) return false;

            _dbContext.Tipos.Add (Tipo);
            await _dbContext.SaveChangesAsync ();

            return true;
        }

        public async Task<bool> Delete () {
            if (TipoNaoEncontrado) return false;

            _dbContext.Tipos.Remove (Tipo);
            await _dbContext.SaveChangesAsync ();

            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Clientes;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Models.ServiceModel
{
    public class ClienteGerenciamento
    {
        private ApiDbContext _dbContext;
        private IServiceProvider _provider;

        public Cliente Cliente { get; private set; }
        public ICollection<Cliente> Clientes { get; private set; }
        public bool ClienteCadastrado { get; set; }
        public bool ClienteNaoEncontrado { get; set; }
        public bool SemClientesCadastros { get; set; }

        public ClienteGerenciamento(ApiDbContext dbContext, IServiceProvider provider){
            _dbContext = dbContext;
            _provider = provider;
        }

        public async Task GetById(long id)
        {
            var clienteValidation = _provider.GetRequiredService<ClienteValidation>();

            Cliente = await _dbContext.Clientes
                .WhereById(id)
                .SingleOrDefaultAsync();
            
            ClienteNaoEncontrado = clienteValidation.ClienteNaoEncontrado(Cliente);
            if(ClienteNaoEncontrado) return;
        }

        public async Task GetAll()
        {
            Clientes = await _dbContext.Clientes
                .ToListAsync();

            SemClientesCadastros = !Clientes.Any();
        }

        public async Task<bool> Insert(Cliente cliente)
        {
            var clienteValidation = _provider.GetRequiredService<ClienteValidation>();

            Cliente = cliente;

            ClienteCadastrado = await clienteValidation.ClienteCadastrado(Cliente);
            if(ClienteCadastrado) return false; 

            _dbContext.Clientes.Add(Cliente);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update()
        {
            var clienteValidation = _provider.GetRequiredService<ClienteValidation>();
            
            if(ClienteNaoEncontrado) return false;

            ClienteCadastrado = await clienteValidation.ClienteCadastrado(Cliente);
            if(ClienteCadastrado) return false;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete()
        {
            if(ClienteNaoEncontrado) return false;

            _dbContext.Clientes.Remove(Cliente);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
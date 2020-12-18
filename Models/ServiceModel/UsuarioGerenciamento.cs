using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using apiEmprestimoJogos.Models.ValidationServiceModel;
using HashidsNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apiEmprestimoJogos.Models.ServiceModel {
    public class UsuarioGerenciamento {
        private ApiDbContext _dbContext;
        private IServiceProvider _provider;

        public Usuario Usuario { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
        public bool UsuarioNaoEncontrado { get; set; }
        public bool UsuariosNaoCadastrados { get; set; }
        public bool UsuarioCadastrado { get; set; }
        public bool UsuarioNaoAutenticado { get; set; }

        public UsuarioGerenciamento (ApiDbContext dbContext, IServiceProvider provider) {
            _dbContext = dbContext;
            _provider = provider;
        }

        public async Task GetById(long id)
        {
            var usuarioValidation = _provider.GetRequiredService<UsuarioValidation> ();

            Usuario = await _dbContext.Usuarios
                .WhereById(id)
                .SingleOrDefaultAsync();
            
            UsuarioNaoEncontrado = usuarioValidation.UsuarioNaoEncontrado(Usuario);
            if(UsuarioNaoEncontrado) return;
        }

        public async Task GetAll(){
            Usuarios = await _dbContext.Usuarios
                .ToListAsync();
            
            UsuariosNaoCadastrados = !Usuarios.Any();
        }

        public async Task<bool> Autenticar(Usuario usuario)
        {
            var usuarioValidation = _provider.GetRequiredService<UsuarioValidation> ();
            
            UsuarioNaoAutenticado = !await usuarioValidation.UsuarioCadastrado(usuario); 
            if(UsuarioNaoAutenticado) return false;
            
            Usuario = await _dbContext.Usuarios
                .WhereUsuario(usuario.Codigo)
                .WhereSenha(usuario.Senha)
                .SingleOrDefaultAsync();
            
            return true;
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            var usuarioValidation = _provider.GetRequiredService<UsuarioValidation> ();

            Usuario = usuario;

            UsuarioCadastrado = await usuarioValidation.UsuarioCadastrado(Usuario);
            if(UsuarioCadastrado) return false;

            _dbContext.Usuarios.Add(Usuario);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update()
        {
            var usuarioValidation = _provider.GetRequiredService<UsuarioValidation>();

            if(UsuarioNaoEncontrado) return false;

            UsuarioCadastrado = await usuarioValidation.UsuarioCadastrado(Usuario);
            if(UsuarioCadastrado) return false;
            
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete()
        {
            if(UsuarioNaoEncontrado) return false;

            _dbContext.Usuarios.Remove(Usuario);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
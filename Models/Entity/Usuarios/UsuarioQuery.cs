using System.Linq;
using HashidsNet;

namespace apiEmprestimoJogos.Models.Entity.Usuarios
{
    public static class UsuarioQuery
    {
        public static IQueryable<Usuario> WhereById(this IQueryable<Usuario> usuarios, long id)
        {
            return usuarios.Where(usuario => usuario.Id == id);
        }

        public static IQueryable<Usuario> WhereUsuario(this IQueryable<Usuario> usuarios, string codigo)
        {
            return usuarios.Where(usuario => usuario.Codigo == codigo);
        }

        public static IQueryable<Usuario> WhereSenha(this IQueryable<Usuario> usuarios, string senha)
        {
            return usuarios.Where(usuario => usuario.Senha == senha);
        }
    }
}
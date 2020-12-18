using System.Linq;

namespace apiEmprestimoJogos.Models.Entity.Clientes
{
    public static class ClienteQuery
    {
        public static IQueryable<Cliente> WhereById(this IQueryable<Cliente> clientes, long id)
        {
            return clientes.Where(cliente => cliente.Id == id);
        }

        public static IQueryable<Cliente> WhereAnotherId(this IQueryable<Cliente> clientes, long id)
        {
            return clientes.Where(cliente => cliente.Id != id);
        }

        public static IQueryable<Cliente> WhereNome(this IQueryable<Cliente> clientes, string nome)
        {
            return clientes.Where(cliente => cliente.Nome == nome);
        }

        public static IQueryable<Cliente> WhereCodigo(this IQueryable<Cliente> clientes, int codigo)
        {
            return clientes.Where(cliente => cliente.Codigo == codigo);
        }
    }
}
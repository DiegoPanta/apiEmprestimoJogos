using System.Linq;

namespace apiEmprestimoJogos.Models.Entity.Tipos
{
    public static class TipoQuery
    {
        public static IQueryable<Tipo> WhereById(this IQueryable<Tipo> tipos, long id)
        {
            return tipos.Where(tipo => tipo.Id == id);
        }

        public static IQueryable<Tipo> WhereDescricao(this IQueryable<Tipo> tipos, string descricao)
        {
            return tipos.Where(tipo => tipo.Descricao == descricao);
        }
    }
}
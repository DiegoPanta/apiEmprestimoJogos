using System.Linq;

namespace apiEmprestimoJogos.Models.Entity.Midias {
    public static class MidiaQuery {
        public static IQueryable<Midia> WhereById (this IQueryable<Midia> midias, long id) {
            return midias.Where (midia => midia.Id == id);
        }

        public static IQueryable<Midia> WhereDescricao (this IQueryable<Midia> midias, string descricao) {
            return midias.Where (midia => midia.Descricao == descricao);
        }
    }
}
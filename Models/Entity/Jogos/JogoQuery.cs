using System.Linq;

namespace apiEmprestimoJogos.Models.Entity.Jogos
{
    public static class JogoQuery
    {
        public static IQueryable<Jogo> WhereById(this IQueryable<Jogo> jogos, long id)
        {
            return jogos.Where(jogo => jogo.Id == id);
        }

        public static IQueryable<Jogo> WhereAnotherId(this IQueryable<Jogo> jogos, long id)
        {
            return jogos.Where(jogo => jogo.Id != id);
        }

        public static IQueryable<Jogo> WhereCodigo(this IQueryable<Jogo> jogos, int codigo)
        {
            return jogos.Where(jogo => jogo.Codigo == codigo);
        }
    }
}
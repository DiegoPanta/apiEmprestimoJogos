using System.Linq;

namespace apiEmprestimoJogos.Models.Entity.Generos
{
    public static class GeneroQuery
    {
        public static IQueryable<Genero> WhereById(this IQueryable<Genero> generos, long id)
        {
            return generos.Where(genero => genero.Id == id);
        }

        public static IQueryable<Genero> WhereDescricao(this IQueryable<Genero> generos, string descricao)
        {
            return generos.Where(genero => genero.Descricao == descricao);
        }
        
    }
}
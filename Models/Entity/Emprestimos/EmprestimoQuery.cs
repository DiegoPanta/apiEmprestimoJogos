using System;
using System.Linq;

namespace apiEmprestimoJogos.Models.Entity.Emprestimos {
    public static class EmprestimoQuery {
        public static IQueryable<Emprestimo> WhereById (this IQueryable<Emprestimo> emprestimos, long id) {
            return emprestimos.Where (emprestimo => emprestimo.Id == id);
        }

        public static IQueryable<Emprestimo> WhereDevolucao (this IQueryable<Emprestimo> emprestimos) {
            return emprestimos.Where (emprestimo => emprestimo.DataDevolucao != null);
        }
    }
}
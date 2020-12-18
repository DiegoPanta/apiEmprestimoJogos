using System.Threading.Tasks;
using apiEmprestimoJogos.Models.Entity.Clientes;
using apiEmprestimoJogos.Models.Entity.Emprestimos;
using apiEmprestimoJogos.Models.Entity.Generos;
using apiEmprestimoJogos.Models.Entity.Jogos;
using apiEmprestimoJogos.Models.Entity.Midias;
using apiEmprestimoJogos.Models.Entity.Tipos;
using apiEmprestimoJogos.Models.Entity.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace apiEmprestimoJogos.Models.Entity {
    public class ApiDbContext : DbContext {
        public ApiDbContext (DbContextOptions<ApiDbContext> options) : base (options) {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Midia> Midias { get; set; }

        public virtual async Task<int> ExecuteSqlRawAsync (string sql, params object[] parameters) {
            return await Database.ExecuteSqlRawAsync (sql, parameters);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Usuario>().Map();
            modelBuilder.Entity<Cliente>().Map();
            modelBuilder.Entity<Emprestimo>().Map();
            modelBuilder.Entity<Jogo>().Map();
            modelBuilder.Entity<Tipo>().Map();
            modelBuilder.Entity<Genero>().Map();
            modelBuilder.Entity<Midia>().Map();
        }
    }
}
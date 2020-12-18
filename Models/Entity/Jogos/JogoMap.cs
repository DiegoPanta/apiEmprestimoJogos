using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEmprestimoJogos.Models.Entity.Jogos
{
    public static class JogoMap
    {
        public static void Map(this EntityTypeBuilder<Jogo> entity)
        {
            entity.ToTable("Jogo", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.IdTipo).HasColumnName("IdTipo").IsRequired();
            entity.Property(p => p.IdGenero).HasColumnName("IdGenero").IsRequired();
            entity.Property(p => p.IdMidia).HasColumnName("IdMidia").IsRequired();
            entity.Property(p => p.Codigo).HasColumnName("Codigo").IsRequired();
            entity.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired();
            entity.Property(p => p.Ano).HasColumnName("Ano").IsRequired();

            entity.HasMany(p => p.Emprestimos).WithOne(p => p.Jogo).HasForeignKey(p => p.IdJogo).OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(p => p.IdTipo);
            entity.HasIndex(p => p.IdGenero);
            entity.HasIndex(p => p.IdMidia);
            entity.HasIndex(p => p.Codigo);
            entity.HasIndex(p => p.Nome);
            entity.HasIndex(p => p.Ano);
        }
    }
}
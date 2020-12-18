using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEmprestimoJogos.Models.Entity.Tipos
{
    public static class TipoMap
    {
        public static void Map(this EntityTypeBuilder<Tipo> entity)
        {
            entity.ToTable("Tipo", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(100).IsRequired();

            entity.HasMany(p => p.Jogos).WithOne(p => p.Tipo).HasForeignKey(p => p.IdTipo).OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(p => p.Descricao);
        }
    }
}
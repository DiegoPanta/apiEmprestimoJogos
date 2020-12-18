using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEmprestimoJogos.Models.Entity.Midias
{
    public static class MidiaMap
    {
        public static void Map(this EntityTypeBuilder<Midia> entity)
        {
            entity.ToTable("Midia", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(100).IsRequired();

            entity.HasMany(p => p.Jogos).WithOne(p => p.Midia).HasForeignKey(p => p.IdMidia).OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(p => p.Descricao);
        }
    }
}
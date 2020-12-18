using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEmprestimoJogos.Models.Entity.Generos
{
    public static class GeneroMap
    {
        public static void Map(this EntityTypeBuilder<Genero> entity)
        {
            entity.ToTable("Genero", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(100).IsRequired();

            entity.HasMany(p => p.Jogos).WithOne(p => p.Genero).HasForeignKey(p => p.IdGenero).OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(p => p.Descricao);
        }
    }
}
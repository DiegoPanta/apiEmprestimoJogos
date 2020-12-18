using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEmprestimoJogos.Models.Entity.Clientes
{
    public static class ClienteMap
    {
        public static void Map(this EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("Cliente", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.IdUsuario).HasColumnName("IdUsuario").IsRequired();
            entity.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired();
            entity.Property(p => p.Codigo).HasColumnName("Codigo").IsRequired();
            entity.Property(p => p.Telefone).HasColumnName("Telefone").HasMaxLength(15).IsRequired();

            entity.HasMany(p => p.Emprestimos).WithOne(p => p.Cliente).HasForeignKey(p => p.IdCliente).OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(p => p.Nome);
            entity.HasIndex(p => p.Codigo);
        }
    }
}
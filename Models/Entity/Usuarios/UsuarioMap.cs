using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEmprestimoJogos.Models.Entity.Usuarios
{
    public static class UsuarioMap
    {
        public static void Map(this EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("Usuario", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.Codigo).HasColumnName("Codigo").HasMaxLength(255).IsRequired();
            entity.Property(p => p.Senha).HasColumnName("Senha").HasMaxLength(255).IsRequired();

            entity.HasMany(p => p.Clientes).WithOne(p => p.Usuario).HasForeignKey(p => p.IdUsuario).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
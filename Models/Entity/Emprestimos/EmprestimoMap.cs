using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiEmprestimoJogos.Models.Entity.Emprestimos
{
    public static class EmprestimoMap
    {
        public static void Map(this EntityTypeBuilder<Emprestimo> entity)
        {
            entity.ToTable("Emprestimo", "dbo");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.IdJogo).HasColumnName("IdJogo").IsRequired();
            entity.Property(p => p.IdCliente).HasColumnName("IdCliente").IsRequired();
            entity.Property(p => p.CodigoCliente).HasColumnName("CodigoCliente").IsRequired();
            entity.Property(p => p.DataEmprestimo).HasColumnName("DataEmprestimo").IsRequired();
            entity.Property(p => p.DevolucaoPrevista).HasColumnName("DevolucaoPrevista");
            entity.Property(p => p.DataDevolucao).HasColumnName("DataDevolucao");

            entity.HasIndex(p => p.IdJogo);
            entity.HasIndex(p => p.IdCliente);
            entity.HasIndex(p => p.CodigoCliente);
            entity.HasIndex(p => p.DataEmprestimo);
            entity.HasIndex(p => p.DataDevolucao);
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiEmprestimoJogos.Models.Entity;

namespace apiEmprestimoJogos.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20201216012955_AddTableMidia")]
    partial class AddTableMidia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Clientes.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Codigo")
                        .HasColumnName("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnName("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("Telefone")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("Codigo");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Nome");

                    b.ToTable("Cliente","dbo");
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Emprestimos.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoCliente")
                        .HasColumnName("CodigoCliente")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnName("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnName("DataEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DevolucaoPrevista")
                        .HasColumnName("DevolucaoPrevista")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnName("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdJogo")
                        .HasColumnName("IdJogo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoCliente");

                    b.HasIndex("DataDevolucao");

                    b.HasIndex("DataEmprestimo");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdJogo");

                    b.ToTable("Emprestimo","dbo");
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Generos.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Descricao");

                    b.ToTable("Genero","dbo");
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Jogos.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnName("Ano")
                        .HasColumnType("int");

                    b.Property<int>("Codigo")
                        .HasColumnName("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("IdGenero")
                        .HasColumnName("IdGenero")
                        .HasColumnType("int");

                    b.Property<int>("IdMidia")
                        .HasColumnName("IdMidia")
                        .HasColumnType("int");

                    b.Property<int>("IdTipo")
                        .HasColumnName("IdTipo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Ano");

                    b.HasIndex("Codigo");

                    b.HasIndex("IdGenero");

                    b.HasIndex("IdMidia");

                    b.HasIndex("IdTipo");

                    b.HasIndex("Nome");

                    b.ToTable("Jogo","dbo");
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Midias.Midia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Descricao");

                    b.ToTable("Midia","dbo");
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Tipos.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Descricao");

                    b.ToTable("Tipo","dbo");
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Usuarios.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("Codigo")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Usuario","dbo");
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Clientes.Cliente", b =>
                {
                    b.HasOne("apiEmprestimoJogos.Models.Entity.Usuarios.Usuario", "Usuario")
                        .WithMany("Clientes")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Emprestimos.Emprestimo", b =>
                {
                    b.HasOne("apiEmprestimoJogos.Models.Entity.Clientes.Cliente", "Cliente")
                        .WithMany("Emprestimos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiEmprestimoJogos.Models.Entity.Jogos.Jogo", "Jogo")
                        .WithMany("Emprestimos")
                        .HasForeignKey("IdJogo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("apiEmprestimoJogos.Models.Entity.Jogos.Jogo", b =>
                {
                    b.HasOne("apiEmprestimoJogos.Models.Entity.Generos.Genero", "Genero")
                        .WithMany("Jogos")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiEmprestimoJogos.Models.Entity.Midias.Midia", "Midia")
                        .WithMany("Jogos")
                        .HasForeignKey("IdMidia")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apiEmprestimoJogos.Models.Entity.Tipos.Tipo", "Tipo")
                        .WithMany("Jogos")
                        .HasForeignKey("IdTipo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

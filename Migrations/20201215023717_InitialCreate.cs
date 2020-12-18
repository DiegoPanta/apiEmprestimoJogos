using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiEmprestimoJogos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Genero",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 255, nullable: false),
                    Senha = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipo = table.Column<int>(nullable: false),
                    IdGenero = table.Column<int>(nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Midia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogo_Genero_IdGenero",
                        column: x => x.IdGenero,
                        principalSchema: "dbo",
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jogo_Tipo_IdTipo",
                        column: x => x.IdTipo,
                        principalSchema: "dbo",
                        principalTable: "Tipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJogo = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    CodigoCliente = table.Column<int>(nullable: false),
                    DataEmprestimo = table.Column<DateTime>(nullable: false),
                    DevolucaoPrevista = table.Column<DateTime>(nullable: true),
                    DataDevolucao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalSchema: "dbo",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Jogo_IdJogo",
                        column: x => x.IdJogo,
                        principalSchema: "dbo",
                        principalTable: "Jogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Codigo",
                schema: "dbo",
                table: "Cliente",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdUsuario",
                schema: "dbo",
                table: "Cliente",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nome",
                schema: "dbo",
                table: "Cliente",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_CodigoCliente",
                schema: "dbo",
                table: "Emprestimo",
                column: "CodigoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_DataDevolucao",
                schema: "dbo",
                table: "Emprestimo",
                column: "DataDevolucao");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_DataEmprestimo",
                schema: "dbo",
                table: "Emprestimo",
                column: "DataEmprestimo");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdCliente",
                schema: "dbo",
                table: "Emprestimo",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_IdJogo",
                schema: "dbo",
                table: "Emprestimo",
                column: "IdJogo");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_Descricao",
                schema: "dbo",
                table: "Genero",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_Ano",
                schema: "dbo",
                table: "Jogo",
                column: "Ano");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_Codigo",
                schema: "dbo",
                table: "Jogo",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_IdGenero",
                schema: "dbo",
                table: "Jogo",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_IdTipo",
                schema: "dbo",
                table: "Jogo",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_Nome",
                schema: "dbo",
                table: "Jogo",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Descricao",
                schema: "dbo",
                table: "Tipo",
                column: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Jogo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Genero",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tipo",
                schema: "dbo");
        }
    }
}

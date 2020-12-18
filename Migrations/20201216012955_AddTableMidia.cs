using Microsoft.EntityFrameworkCore.Migrations;

namespace apiEmprestimoJogos.Migrations
{
    public partial class AddTableMidia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Midia",
                schema: "dbo",
                table: "Jogo");

            migrationBuilder.AddColumn<int>(
                name: "IdMidia",
                schema: "dbo",
                table: "Jogo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Midia",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midia", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_IdMidia",
                schema: "dbo",
                table: "Jogo",
                column: "IdMidia");

            migrationBuilder.CreateIndex(
                name: "IX_Midia_Descricao",
                schema: "dbo",
                table: "Midia",
                column: "Descricao");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogo_Midia_IdMidia",
                schema: "dbo",
                table: "Jogo",
                column: "IdMidia",
                principalSchema: "dbo",
                principalTable: "Midia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogo_Midia_IdMidia",
                schema: "dbo",
                table: "Jogo");

            migrationBuilder.DropTable(
                name: "Midia",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Jogo_IdMidia",
                schema: "dbo",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "IdMidia",
                schema: "dbo",
                table: "Jogo");

            migrationBuilder.AddColumn<int>(
                name: "Midia",
                schema: "dbo",
                table: "Jogo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

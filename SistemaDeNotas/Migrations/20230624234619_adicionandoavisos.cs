using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNotas.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoavisos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioName",
                table: "Notas",
                newName: "UsuarioTurma");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Avisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvisoTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvisoCorpo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avisos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avisos");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "UsuarioTurma",
                table: "Notas",
                newName: "UsuarioName");
        }
    }
}

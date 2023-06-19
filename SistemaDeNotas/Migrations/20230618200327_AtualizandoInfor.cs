using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNotas.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoInfor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Notas");
        }
    }
}

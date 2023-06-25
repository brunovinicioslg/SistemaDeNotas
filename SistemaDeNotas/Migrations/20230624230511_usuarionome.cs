using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNotas.Migrations
{
    /// <inheritdoc />
    public partial class usuarionome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioName",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioName",
                table: "Notas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNotas.Migrations
{
    /// <inheritdoc />
    public partial class CriandoVinculoEntreTAbelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_UsuarioID",
                table: "Notas",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_UsuarioID",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Notas");
        }
    }
}

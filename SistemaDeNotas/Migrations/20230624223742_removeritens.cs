using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeNotas.Migrations
{
    /// <inheritdoc />
    public partial class removeritens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Notas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Notas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Notas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}

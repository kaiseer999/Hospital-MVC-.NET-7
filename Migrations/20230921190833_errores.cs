using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    /// <inheritdoc />
    public partial class errores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolIdRol",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolIdRol",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "RolIdRol",
                table: "Usuario",
                newName: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Usuario",
                newName: "RolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolIdRol",
                table: "Usuario",
                column: "RolIdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolIdRol",
                table: "Usuario",
                column: "RolIdRol",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

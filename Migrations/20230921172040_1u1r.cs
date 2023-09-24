using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    /// <inheritdoc />
    public partial class _1u1r : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "RolIdRol",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolIdRol",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolIdRol",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RolIdRol",
                table: "Usuario");

            migrationBuilder.CreateTable(
                name: "UsuariosRoles",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRoles", x => new { x.IdUsuario, x.IdRol });
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_IdRol",
                table: "UsuariosRoles",
                column: "IdRol");
        }
    }
}

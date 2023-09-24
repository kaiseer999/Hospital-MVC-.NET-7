using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    /// <inheritdoc />
    public partial class idu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioIdentificacion",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuarioIdentificacion",
                table: "Usuario");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    /// <inheritdoc />
    public partial class EmailToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "IdEps",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoriaClinicaIdHcu",
                table: "EPS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EPS_HistoriaClinicaIdHcu",
                table: "EPS",
                column: "HistoriaClinicaIdHcu");

            migrationBuilder.AddForeignKey(
                name: "FK_EPS_HistoriaClinica_HistoriaClinicaIdHcu",
                table: "EPS",
                column: "HistoriaClinicaIdHcu",
                principalTable: "HistoriaClinica",
                principalColumn: "IdHcu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

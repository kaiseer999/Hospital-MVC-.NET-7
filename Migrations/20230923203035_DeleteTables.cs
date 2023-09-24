using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaClinica_Dcorporale_IdDcorporales",
                table: "HistoriaClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaClinica_Diagnostico_IdDiag",
                table: "HistoriaClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaClinica_MotivoConsult_IdMconsulta",
                table: "HistoriaClinica");

            migrationBuilder.DropTable(
                name: "Dcorporale");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "MotivoConsult");

            migrationBuilder.DropIndex(
                name: "IX_HistoriaClinica_IdDcorporales",
                table: "HistoriaClinica");

            migrationBuilder.DropIndex(
                name: "IX_HistoriaClinica_IdDiag",
                table: "HistoriaClinica");

            migrationBuilder.DropIndex(
                name: "IX_HistoriaClinica_IdMconsulta",
                table: "HistoriaClinica");

            migrationBuilder.DropColumn(
                name: "IdDcorporales",
                table: "HistoriaClinica");

            migrationBuilder.DropColumn(
                name: "IdDiag",
                table: "HistoriaClinica");

            migrationBuilder.DropColumn(
                name: "IdMconsulta",
                table: "HistoriaClinica");

            migrationBuilder.AddColumn<float>(
                name: "Altura",
                table: "InsGeneral",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ComentarioD",
                table: "InsGeneral",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ComentarioMc",
                table: "InsGeneral",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FrecuenciaCardiaca",
                table: "InsGeneral",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrecuenciaRespiratoria",
                table: "InsGeneral",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Imc",
                table: "InsGeneral",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PesoIdeal",
                table: "InsGeneral",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PesoReal",
                table: "InsGeneral",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Temperatura",
                table: "InsGeneral",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "ComentarioD",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "ComentarioMc",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "FrecuenciaCardiaca",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "FrecuenciaRespiratoria",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "Imc",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "PesoIdeal",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "PesoReal",
                table: "InsGeneral");

            migrationBuilder.DropColumn(
                name: "Temperatura",
                table: "InsGeneral");

            migrationBuilder.AddColumn<int>(
                name: "IdDcorporales",
                table: "HistoriaClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDiag",
                table: "HistoriaClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMconsulta",
                table: "HistoriaClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dcorporale",
                columns: table => new
                {
                    IdDcorporales = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    FrecuenciaCardiaca = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaRespiratoria = table.Column<int>(type: "int", nullable: false),
                    Imc = table.Column<float>(type: "real", nullable: false),
                    PesoIdeal = table.Column<float>(type: "real", nullable: false),
                    PesoReal = table.Column<float>(type: "real", nullable: false),
                    Temperatura = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dcorporale", x => x.IdDcorporales);
                    table.ForeignKey(
                        name: "FK_Dcorporale_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    IdDiag = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    ComentarioD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.IdDiag);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotivoConsult",
                columns: table => new
                {
                    IdMconsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    ComentarioMc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoConsult", x => x.IdMconsulta);
                    table.ForeignKey(
                        name: "FK_MotivoConsult_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdDcorporales",
                table: "HistoriaClinica",
                column: "IdDcorporales",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdDiag",
                table: "HistoriaClinica",
                column: "IdDiag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdMconsulta",
                table: "HistoriaClinica",
                column: "IdMconsulta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dcorporale_IdUsuario",
                table: "Dcorporale",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_IdUsuario",
                table: "Diagnostico",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotivoConsult_IdUsuario",
                table: "MotivoConsult",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaClinica_Dcorporale_IdDcorporales",
                table: "HistoriaClinica",
                column: "IdDcorporales",
                principalTable: "Dcorporale",
                principalColumn: "IdDcorporales",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaClinica_Diagnostico_IdDiag",
                table: "HistoriaClinica",
                column: "IdDiag",
                principalTable: "Diagnostico",
                principalColumn: "IdDiag",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaClinica_MotivoConsult_IdMconsulta",
                table: "HistoriaClinica",
                column: "IdMconsulta",
                principalTable: "MotivoConsult",
                principalColumn: "IdMconsulta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

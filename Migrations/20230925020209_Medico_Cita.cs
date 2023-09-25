using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    /// <inheritdoc />
    public partial class Medico_Cita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "HistoriaClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicoIdMedico",
                table: "HistoriaClinica",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medico_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario"
                       );
                });

            migrationBuilder.CreateTable(
                name: "CitaMedica",
                columns: table => new
                {
                    IdCitaMedica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Consultorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaMedica", x => x.IdCitaMedica);
                    table.ForeignKey(
                        name: "FK_CitaMedica_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico");
                    table.ForeignKey(
                        name: "FK_CitaMedica_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_MedicoIdMedico",
                table: "HistoriaClinica",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_IdMedico",
                table: "CitaMedica",
                column: "IdMedico"
                );

            migrationBuilder.CreateIndex(
                name: "IX_CitaMedica_IdUsuario",
                table: "CitaMedica",
                column: "IdUsuario"
                );

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdUsuario",
                table: "Medico",
                column: "IdUsuario"
                );

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaClinica_Medico_MedicoIdMedico",
                table: "HistoriaClinica",
                column: "MedicoIdMedico",
                principalTable: "Medico",
                principalColumn: "IdMedico")
               ;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaClinica_Medico_MedicoIdMedico",
                table: "HistoriaClinica");

            migrationBuilder.DropTable(
                name: "CitaMedica");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropIndex(
                name: "IX_HistoriaClinica_MedicoIdMedico",
                table: "HistoriaClinica");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "HistoriaClinica");

            migrationBuilder.DropColumn(
                name: "MedicoIdMedico",
                table: "HistoriaClinica");
        }
    }
}

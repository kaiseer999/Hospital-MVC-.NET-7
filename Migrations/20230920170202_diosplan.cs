using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    /// <inheritdoc />
    public partial class diosplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Dcorporale",
                columns: table => new
                {
                    IdDcorporales = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    PesoReal = table.Column<float>(type: "real", nullable: false),
                    PesoIdeal = table.Column<float>(type: "real", nullable: false),
                    Imc = table.Column<float>(type: "real", nullable: false),
                    Temperatura = table.Column<float>(type: "real", nullable: false),
                    FrecuenciaCardiaca = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaRespiratoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dcorporale", x => x.IdDcorporales);
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
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadHereditaria",
                columns: table => new
                {
                    IdEh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioidUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadHereditaria", x => x.IdEh);
                });

            migrationBuilder.CreateTable(
                name: "EPS",
                columns: table => new
                {
                    IdEps = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoriaClinicaIdHcu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPS", x => x.IdEps);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    IdEps = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPSIdEps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_EPS_EPSIdEps",
                        column: x => x.EPSIdEps,
                        principalTable: "EPS",
                        principalColumn: "IdEps",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsGeneral",
                columns: table => new
                {
                    IdIgeneral = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    ComentarioIg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsGeneral", x => x.IdIgeneral);
                    table.ForeignKey(
                        name: "FK_InsGeneral_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaClinica",
                columns: table => new
                {
                    IdHcu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdDiag = table.Column<int>(type: "int", nullable: false),
                    IdDcorporales = table.Column<int>(type: "int", nullable: false),
                    IdIgeneral = table.Column<int>(type: "int", nullable: false),
                    IdEh = table.Column<int>(type: "int", nullable: false),
                    IdMconsulta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinica", x => x.IdHcu);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Dcorporale_IdDcorporales",
                        column: x => x.IdDcorporales,
                        principalTable: "Dcorporale",
                        principalColumn: "IdDcorporales",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Diagnostico_IdDiag",
                        column: x => x.IdDiag,
                        principalTable: "Diagnostico",
                        principalColumn: "IdDiag",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_EnfermedadHereditaria_IdEh",
                        column: x => x.IdEh,
                        principalTable: "EnfermedadHereditaria",
                        principalColumn: "IdEh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_InsGeneral_IdIgeneral",
                        column: x => x.IdIgeneral,
                        principalTable: "InsGeneral",
                        principalColumn: "IdIgeneral",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_MotivoConsult_IdMconsulta",
                        column: x => x.IdMconsulta,
                        principalTable: "MotivoConsult",
                        principalColumn: "IdMconsulta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_EnfermedadHereditaria_UsuarioidUsuario",
                table: "EnfermedadHereditaria",
                column: "UsuarioidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EPS_HistoriaClinicaIdHcu",
                table: "EPS",
                column: "HistoriaClinicaIdHcu");

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
                name: "IX_HistoriaClinica_IdEh",
                table: "HistoriaClinica",
                column: "IdEh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdIgeneral",
                table: "HistoriaClinica",
                column: "IdIgeneral",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdMconsulta",
                table: "HistoriaClinica",
                column: "IdMconsulta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdUsuario",
                table: "HistoriaClinica",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsGeneral_IdUsuario",
                table: "InsGeneral",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotivoConsult_IdUsuario",
                table: "MotivoConsult",
                column: "IdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EPSIdEps",
                table: "Usuario",
                column: "EPSIdEps");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_IdRol",
                table: "UsuariosRoles",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Dcorporale_Usuario_IdUsuario",
                table: "Dcorporale",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Usuario_IdUsuario",
                table: "Diagnostico",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnfermedadHereditaria_Usuario_UsuarioidUsuario",
                table: "EnfermedadHereditaria",
                column: "UsuarioidUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EPS_HistoriaClinica_HistoriaClinicaIdHcu",
                table: "EPS",
                column: "HistoriaClinicaIdHcu",
                principalTable: "HistoriaClinica",
                principalColumn: "IdHcu",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dcorporale_Usuario_IdUsuario",
                table: "Dcorporale");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Usuario_IdUsuario",
                table: "Diagnostico");

            migrationBuilder.DropForeignKey(
                name: "FK_EnfermedadHereditaria_Usuario_UsuarioidUsuario",
                table: "EnfermedadHereditaria");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaClinica_Usuario_IdUsuario",
                table: "HistoriaClinica");

            migrationBuilder.DropForeignKey(
                name: "FK_InsGeneral_Usuario_IdUsuario",
                table: "InsGeneral");

            migrationBuilder.DropForeignKey(
                name: "FK_MotivoConsult_Usuario_IdUsuario",
                table: "MotivoConsult");

            migrationBuilder.DropTable(
                name: "UsuariosRoles");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "EPS");

            migrationBuilder.DropTable(
                name: "HistoriaClinica");

            migrationBuilder.DropTable(
                name: "Dcorporale");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "EnfermedadHereditaria");

            migrationBuilder.DropTable(
                name: "InsGeneral");

            migrationBuilder.DropTable(
                name: "MotivoConsult");
        }
    }
}

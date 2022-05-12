using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ConciliacionCasetasFase11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "trafico");

            migrationBuilder.CreateTable(
                name: "ConciliacionCaseta",
                schema: "trafico",
                columns: table => new
                {
                    ConciliacionCasetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConciliacionCaseta", x => x.ConciliacionCasetaId);
                    table.ForeignKey(
                        name: "FK_ConciliacionCaseta_Empresa _EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "corporativo",
                        principalTable: "Empresa ",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConciliacionCasetaArchivo",
                schema: "trafico",
                columns: table => new
                {
                    ConciliacionCasetaArchivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConciliacionCasetaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", maxLength: 250, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstatusArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConciliacionCasetaArchivo", x => x.ConciliacionCasetaArchivoId);
                    table.ForeignKey(
                        name: "FK_ConciliacionCasetaArchivo_ConciliacionCaseta_ConciliacionCasetaId",
                        column: x => x.ConciliacionCasetaId,
                        principalSchema: "trafico",
                        principalTable: "ConciliacionCaseta",
                        principalColumn: "ConciliacionCasetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConciliacionCasetaArchivoEvento",
                schema: "trafico",
                columns: table => new
                {
                    ConciliacionCasetaArchivoEventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConciliacionCasetaArchivoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaveRed = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    ClaveFideicomiso = table.Column<int>(type: "int", nullable: false),
                    NumeroPeriodo = table.Column<int>(type: "int", nullable: false),
                    TipoPeriodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaveEmpresa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TarjetaIDMX = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NumeroEconomico = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaCruce = table.Column<DateTime>(type: "datetime2", maxLength: 250, nullable: false),
                    HoraCruce = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Clase = table.Column<int>(type: "int", nullable: false),
                    NombreCaseta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCarril = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImporteAl100 = table.Column<decimal>(type: "decimal(18,2)", maxLength: 250, nullable: false),
                    ImporteFacturado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroPlaza = table.Column<int>(type: "int", nullable: false),
                    ControlInternoProveedor1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlInternoProveedor2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlInternoProveedor3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlInternoProveedor4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCargaBanco = table.Column<int>(type: "int", nullable: false),
                    FechaCargoBanco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstatusCruce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BActivo = table.Column<bool>(type: "bit", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConciliacionCasetaArchivoEvento", x => x.ConciliacionCasetaArchivoEventoId);
                    table.ForeignKey(
                        name: "FK_ConciliacionCasetaArchivoEvento_ConciliacionCasetaArchivo_ConciliacionCasetaArchivoId",
                        column: x => x.ConciliacionCasetaArchivoId,
                        principalSchema: "trafico",
                        principalTable: "ConciliacionCasetaArchivo",
                        principalColumn: "ConciliacionCasetaArchivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConciliacionCaseta_EmpresaId",
                schema: "trafico",
                table: "ConciliacionCaseta",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConciliacionCasetaArchivo_ConciliacionCasetaId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                column: "ConciliacionCasetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConciliacionCasetaArchivoEvento_ConciliacionCasetaArchivoId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                column: "ConciliacionCasetaArchivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConciliacionCasetaArchivoEvento",
                schema: "trafico");

            migrationBuilder.DropTable(
                name: "ConciliacionCasetaArchivo",
                schema: "trafico");

            migrationBuilder.DropTable(
                name: "ConciliacionCaseta",
                schema: "trafico");
        }
    }
}

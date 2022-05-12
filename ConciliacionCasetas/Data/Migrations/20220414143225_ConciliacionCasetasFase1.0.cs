using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Data.Migrations
{
    public partial class ConciliacionCasetasFase10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "corporativo");

            //migrationBuilder.EnsureSchema(
            //    name: "torreservicio");

            //migrationBuilder.CreateTable(
            //    name: "ListaGenericaTipo",
            //    schema: "torreservicio",
            //    columns: table => new
            //    {
            //        ListaGenericaTipoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cveListaGenericaTipo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        desListaGenericaTipo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ListaGenericaTipo", x => x.ListaGenericaTipoId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ListaGenerica ",
            //    schema: "torreservicio",
            //    columns: table => new
            //    {
            //        ListaGenericaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ListaGenericaTipoId = table.Column<int>(type: "int", nullable: false),
            //        ValorString = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        ValorEntero = table.Column<int>(type: "int", nullable: false),
            //        ValorFlotante = table.Column<float>(type: "real", nullable: false),
            //        cveListaGenerica = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        desListaGenerica = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
            //        Estatus = table.Column<int>(type: "int", nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ListaGenerica ", x => x.ListaGenericaId);
            //        table.ForeignKey(
            //            name: "FK_ListaGenerica _ListaGenericaTipo_ListaGenericaTipoId",
            //            column: x => x.ListaGenericaTipoId,
            //            principalSchema: "torreservicio",
            //            principalTable: "ListaGenericaTipo",
            //            principalColumn: "ListaGenericaTipoId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Geocerca",
            //    schema: "corporativo",
            //    columns: table => new
            //    {
            //        GeocercaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        Poligono = table.Column<Geometry>(type: "geography", nullable: false),
            //        PoligonoComputado = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[Poligono].ToString()"),
            //        Punto = table.Column<Point>(type: "geography", nullable: false),
            //        PuntoComputado = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[Punto].ToString()"),
            //        GeocercaIdExterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        TipoGeocercaId = table.Column<int>(type: "int", nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false),
            //        FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BDireccionAzure = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Geocerca", x => x.GeocercaId);
            //        table.ForeignKey(
            //            name: "FK_Geocerca_ListaGenerica _TipoGeocercaId",
            //            column: x => x.TipoGeocercaId,
            //            principalSchema: "torreservicio",
            //            principalTable: "ListaGenerica ",
            //            principalColumn: "ListaGenericaId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Caseta",
            //    schema: "corporativo",
            //    columns: table => new
            //    {
            //        CasetaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        AliasIave = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        Url = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        MetodoPagoId = table.Column<int>(type: "int", nullable: true),
            //        GeocercaId = table.Column<int>(type: "int", nullable: true),
            //        FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false),
            //        BCasetaActiva = table.Column<bool>(type: "bit", nullable: false),
            //        ArchivoTicketFrente = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        ArchivoTicketAtras = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Caseta", x => x.CasetaId);
            //        table.ForeignKey(
            //            name: "FK_Caseta_Geocerca_GeocercaId",
            //            column: x => x.GeocercaId,
            //            principalSchema: "corporativo",
            //            principalTable: "Geocerca",
            //            principalColumn: "GeocercaId");
            //        table.ForeignKey(
            //            name: "FK_Caseta_ListaGenerica _MetodoPagoId",
            //            column: x => x.MetodoPagoId,
            //            principalSchema: "torreservicio",
            //            principalTable: "ListaGenerica ",
            //            principalColumn: "ListaGenericaId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CampoTicketCaseta",
            //    schema: "corporativo",
            //    columns: table => new
            //    {
            //        CampoTicketCasetaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CasetaId = table.Column<int>(type: "int", nullable: false),
            //        Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false),
            //        TipoDatoId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CampoTicketCaseta", x => x.CampoTicketCasetaId);
            //        table.ForeignKey(
            //            name: "FK_CampoTicketCaseta_Caseta_CasetaId",
            //            column: x => x.CasetaId,
            //            principalSchema: "corporativo",
            //            principalTable: "Caseta",
            //            principalColumn: "CasetaId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CampoTicketCaseta_ListaGenerica _TipoDatoId",
            //            column: x => x.TipoDatoId,
            //            principalSchema: "torreservicio",
            //            principalTable: "ListaGenerica ",
            //            principalColumn: "ListaGenericaId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Carril",
            //    schema: "corporativo",
            //    columns: table => new
            //    {
            //        CarrilId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CasetaId = table.Column<int>(type: "int", nullable: false),
            //        Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
            //        AliasIave = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Carril", x => x.CarrilId);
            //        table.ForeignKey(
            //            name: "FK_Carril_Caseta_CasetaId",
            //            column: x => x.CasetaId,
            //            principalSchema: "corporativo",
            //            principalTable: "Caseta",
            //            principalColumn: "CasetaId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Peaje",
            //    schema: "corporativo",
            //    columns: table => new
            //    {
            //        PeajeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CarrilId = table.Column<int>(type: "int", nullable: false),
            //        Monto = table.Column<decimal>(type: "decimal(20,4)", nullable: false),
            //        TipoEjeId = table.Column<int>(type: "int", nullable: true),
            //        FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Peaje", x => x.PeajeId);
            //        table.ForeignKey(
            //            name: "FK_Peaje_Carril_CarrilId",
            //            column: x => x.CarrilId,
            //            principalSchema: "corporativo",
            //            principalTable: "Carril",
            //            principalColumn: "CarrilId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Peaje_ListaGenerica _TipoEjeId",
            //            column: x => x.TipoEjeId,
            //            principalSchema: "torreservicio",
            //            principalTable: "ListaGenerica ",
            //            principalColumn: "ListaGenericaId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "HistoricoPeaje",
            //    schema: "corporativo",
            //    columns: table => new
            //    {
            //        HistoricoPeajeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PeajeId = table.Column<int>(type: "int", nullable: false),
            //        Monto = table.Column<decimal>(type: "decimal(20,4)", nullable: false),
            //        FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaEdita = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        FechaElimina = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BActivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_HistoricoPeaje", x => x.HistoricoPeajeId);
            //        table.ForeignKey(
            //            name: "FK_HistoricoPeaje_Peaje_PeajeId",
            //            column: x => x.PeajeId,
            //            principalSchema: "corporativo",
            //            principalTable: "Peaje",
            //            principalColumn: "PeajeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_CampoTicketCaseta_CasetaId",
            //    schema: "corporativo",
            //    table: "CampoTicketCaseta",
            //    column: "CasetaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CampoTicketCaseta_TipoDatoId",
            //    schema: "corporativo",
            //    table: "CampoTicketCaseta",
            //    column: "TipoDatoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Carril_CasetaId",
            //    schema: "corporativo",
            //    table: "Carril",
            //    column: "CasetaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Caseta_GeocercaId",
            //    schema: "corporativo",
            //    table: "Caseta",
            //    column: "GeocercaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Caseta_MetodoPagoId",
            //    schema: "corporativo",
            //    table: "Caseta",
            //    column: "MetodoPagoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Geocerca_TipoGeocercaId",
            //    schema: "corporativo",
            //    table: "Geocerca",
            //    column: "TipoGeocercaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_HistoricoPeaje_PeajeId",
            //    schema: "corporativo",
            //    table: "HistoricoPeaje",
            //    column: "PeajeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ListaGenerica _ListaGenericaTipoId",
            //    schema: "torreservicio",
            //    table: "ListaGenerica ",
            //    column: "ListaGenericaTipoId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Peaje_CarrilId",
            //    schema: "corporativo",
            //    table: "Peaje",
            //    column: "CarrilId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Peaje_TipoEjeId",
            //    schema: "corporativo",
            //    table: "Peaje",
            //    column: "TipoEjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CampoTicketCaseta",
            //    schema: "corporativo");

            //migrationBuilder.DropTable(
            //    name: "HistoricoPeaje",
            //    schema: "corporativo");

            //migrationBuilder.DropTable(
            //    name: "Peaje",
            //    schema: "corporativo");

            //migrationBuilder.DropTable(
            //    name: "Carril",
            //    schema: "corporativo");

            //migrationBuilder.DropTable(
            //    name: "Caseta",
            //    schema: "corporativo");

            //migrationBuilder.DropTable(
            //    name: "Geocerca",
            //    schema: "corporativo");

            //migrationBuilder.DropTable(
            //    name: "ListaGenerica ",
            //    schema: "torreservicio");

            //migrationBuilder.DropTable(
            //    name: "ListaGenericaTipo",
            //    schema: "torreservicio");
        }
    }
}

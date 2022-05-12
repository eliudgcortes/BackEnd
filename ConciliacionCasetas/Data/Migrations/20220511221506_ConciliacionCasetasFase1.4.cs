using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ConciliacionCasetasFase14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                newName: "NombreClaseConciliacion");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroPeriodo",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ClaveFideicomiso",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCruceCompleta",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ImporteConciliacion",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ImporteDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NombreCarrilConciliacion",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumeroEconomicoSoloEntero",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ExcelArchivo",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EstatusArchivo",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CantidadConDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CantidadConciliados",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalConDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSinDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEstatus",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriodoProveedor",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriodoProveedorTipo",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCruceCompleta",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "ImporteConciliacion",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "ImporteDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "NombreCarrilConciliacion",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "NumeroEconomicoSoloEntero",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "CantidadConDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "CantidadConciliados",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "TotalConDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "TotalSinDiferencia",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "FechaEstatus",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "Periodo",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "PeriodoProveedor",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "PeriodoProveedorTipo",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.RenameColumn(
                name: "NombreClaseConciliacion",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                newName: "Nombre");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroPeriodo",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClaveFideicomiso",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExcelArchivo",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EstatusArchivo",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

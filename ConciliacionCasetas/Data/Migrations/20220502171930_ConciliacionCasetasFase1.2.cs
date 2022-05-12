using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ConciliacionCasetasFase12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConciliacionCasetaArchivoEvento_ConciliacionCasetaArchivo_ConciliacionCasetaArchivoId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "Nombre",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "Nombre",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.AlterColumn<int>(
                name: "ConciliacionCasetaArchivoId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConciliacionCasetaId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEdita",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaElimina",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlta",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEdita",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClaveRed",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEdita",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaElimina",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlta",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEdita",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ConciliacionCasetaArchivoEvento_ConciliacionCasetaId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                column: "ConciliacionCasetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConciliacionCasetaArchivoEvento_ConciliacionCaseta_ConciliacionCasetaId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                column: "ConciliacionCasetaId",
                principalSchema: "trafico",
                principalTable: "ConciliacionCaseta",
                principalColumn: "ConciliacionCasetaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConciliacionCasetaArchivoEvento_ConciliacionCasetaArchivo_ConciliacionCasetaArchivoId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                column: "ConciliacionCasetaArchivoId",
                principalSchema: "trafico",
                principalTable: "ConciliacionCasetaArchivo",
                principalColumn: "ConciliacionCasetaArchivoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConciliacionCasetaArchivoEvento_ConciliacionCaseta_ConciliacionCasetaId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropForeignKey(
                name: "FK_ConciliacionCasetaArchivoEvento_ConciliacionCasetaArchivo_ConciliacionCasetaArchivoId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropIndex(
                name: "IX_ConciliacionCasetaArchivoEvento_ConciliacionCasetaId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "ConciliacionCasetaId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento");

            migrationBuilder.DropColumn(
                name: "FechaEdita",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "FechaElimina",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "UsuarioAlta",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "UsuarioEdita",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo");

            migrationBuilder.DropColumn(
                name: "ClaveRed",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "FechaEdita",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "FechaElimina",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "UsuarioAlta",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "UsuarioEdita",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                schema: "trafico",
                table: "ConciliacionCaseta");

            migrationBuilder.AlterColumn<int>(
                name: "ConciliacionCasetaArchivoId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                schema: "trafico",
                table: "ConciliacionCasetaArchivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                schema: "trafico",
                table: "ConciliacionCaseta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ConciliacionCasetaArchivoEvento_ConciliacionCasetaArchivo_ConciliacionCasetaArchivoId",
                schema: "trafico",
                table: "ConciliacionCasetaArchivoEvento",
                column: "ConciliacionCasetaArchivoId",
                principalSchema: "trafico",
                principalTable: "ConciliacionCasetaArchivo",
                principalColumn: "ConciliacionCasetaArchivoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

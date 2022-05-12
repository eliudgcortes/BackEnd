using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Empresa ",
            //    schema: "corporativo",
            //    columns: table => new
            //    {
            //        EmpresaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cveEmpresa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        desEmpresa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        IdEmpresaSip = table.Column<int>(type: "int", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
            //        bActivo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Empresa ", x => x.EmpresaId);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Empresa ",
            //    schema: "corporativo");
        }
    }
}

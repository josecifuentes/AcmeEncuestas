using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAcmeEncuestasV1.Migrations
{
    public partial class CambiosEnRelaciones3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Llenarencuesta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoLlenado = table.Column<int>(type: "int", nullable: false),
                    IdCampo = table.Column<int>(type: "int", nullable: false),
                    Datos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llenarencuesta", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Llenarencuesta");
        }
    }
}

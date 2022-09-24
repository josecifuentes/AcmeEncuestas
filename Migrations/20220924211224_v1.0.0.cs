using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAcmeEncuestasV1.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreEncuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionEncuesta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuesta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCampo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tituloCampo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requerido = table.Column<bool>(type: "bit", nullable: false),
                    tipoCampo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncuestaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Campos_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campos_EncuestaId",
                table: "Campos",
                column: "EncuestaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campos");

            migrationBuilder.DropTable(
                name: "Encuesta");
        }
    }
}

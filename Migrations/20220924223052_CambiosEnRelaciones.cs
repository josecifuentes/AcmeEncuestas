using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAcmeEncuestasV1.Migrations
{
    public partial class CambiosEnRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Encuesta_EncuestaId",
                table: "Campos");

            migrationBuilder.AlterColumn<int>(
                name: "EncuestaId",
                table: "Campos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Encuesta_EncuestaId",
                table: "Campos",
                column: "EncuestaId",
                principalTable: "Encuesta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Encuesta_EncuestaId",
                table: "Campos");

            migrationBuilder.AlterColumn<int>(
                name: "EncuestaId",
                table: "Campos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Encuesta_EncuestaId",
                table: "Campos",
                column: "EncuestaId",
                principalTable: "Encuesta",
                principalColumn: "Id");
        }
    }
}

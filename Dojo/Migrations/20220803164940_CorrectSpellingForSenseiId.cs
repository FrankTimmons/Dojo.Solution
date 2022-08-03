using Microsoft.EntityFrameworkCore.Migrations;

namespace Dojo.Migrations
{
    public partial class CorrectSpellingForSenseiId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscipleSensei_Senseis_SenseiId",
                table: "DiscipleSensei");

            migrationBuilder.DropColumn(
                name: "SensieId",
                table: "DiscipleSensei");

            migrationBuilder.AlterColumn<int>(
                name: "SenseiId",
                table: "DiscipleSensei",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscipleSensei_Senseis_SenseiId",
                table: "DiscipleSensei",
                column: "SenseiId",
                principalTable: "Senseis",
                principalColumn: "SenseiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscipleSensei_Senseis_SenseiId",
                table: "DiscipleSensei");

            migrationBuilder.AlterColumn<int>(
                name: "SenseiId",
                table: "DiscipleSensei",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SensieId",
                table: "DiscipleSensei",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscipleSensei_Senseis_SenseiId",
                table: "DiscipleSensei",
                column: "SenseiId",
                principalTable: "Senseis",
                principalColumn: "SenseiId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

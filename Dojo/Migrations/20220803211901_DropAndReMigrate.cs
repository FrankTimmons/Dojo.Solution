using Microsoft.EntityFrameworkCore.Migrations;

namespace Dojo.Migrations
{
    public partial class DropAndReMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Senseis_MartialArtId",
                table: "Senseis",
                column: "MartialArtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Senseis_MartialArts_MartialArtId",
                table: "Senseis",
                column: "MartialArtId",
                principalTable: "MartialArts",
                principalColumn: "MartialArtId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Senseis_MartialArts_MartialArtId",
                table: "Senseis");

            migrationBuilder.DropIndex(
                name: "IX_Senseis_MartialArtId",
                table: "Senseis");
        }
    }
}

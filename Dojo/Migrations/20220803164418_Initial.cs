using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dojo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciples",
                columns: table => new
                {
                    DiscipleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciples", x => x.DiscipleId);
                });

            migrationBuilder.CreateTable(
                name: "MartialArts",
                columns: table => new
                {
                    MartialArtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MartialArts", x => x.MartialArtId);
                });

            migrationBuilder.CreateTable(
                name: "Senseis",
                columns: table => new
                {
                    SenseiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MartialArtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senseis", x => x.SenseiId);
                });

            migrationBuilder.CreateTable(
                name: "DiscipleSensei",
                columns: table => new
                {
                    DiscipleSenseiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscipleId = table.Column<int>(type: "int", nullable: false),
                    SensieId = table.Column<int>(type: "int", nullable: false),
                    SenseiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscipleSensei", x => x.DiscipleSenseiId);
                    table.ForeignKey(
                        name: "FK_DiscipleSensei_Disciples_DiscipleId",
                        column: x => x.DiscipleId,
                        principalTable: "Disciples",
                        principalColumn: "DiscipleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscipleSensei_Senseis_SenseiId",
                        column: x => x.SenseiId,
                        principalTable: "Senseis",
                        principalColumn: "SenseiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscipleSensei_DiscipleId",
                table: "DiscipleSensei",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscipleSensei_SenseiId",
                table: "DiscipleSensei",
                column: "SenseiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscipleSensei");

            migrationBuilder.DropTable(
                name: "MartialArts");

            migrationBuilder.DropTable(
                name: "Disciples");

            migrationBuilder.DropTable(
                name: "Senseis");
        }
    }
}

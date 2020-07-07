using Microsoft.EntityFrameworkCore.Migrations;

namespace HangmanAPI.Migrations
{
    public partial class HangModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Win = table.Column<int>(nullable: false),
                    Loss = table.Column<int>(nullable: false),
                    Abandon = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersStatistics_WordsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "WordsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_WordsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "WordsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStatistics_CategoryId",
                table: "PlayersStatistics",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStatistics_PlayerId",
                table: "PlayersStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_CategoryId",
                table: "Words",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersStatistics");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "WordsCategories");
        }
    }
}

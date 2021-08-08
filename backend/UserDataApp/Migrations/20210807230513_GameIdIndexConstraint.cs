using Microsoft.EntityFrameworkCore.Migrations;

namespace UserDataApp.Migrations
{
    public partial class GameIdIndexConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_Game Id",
                table: "Games",
                column: "Game Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_Game Id",
                table: "Games");
        }
    }
}

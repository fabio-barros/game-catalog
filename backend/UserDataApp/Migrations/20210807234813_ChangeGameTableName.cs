using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UserDataApp.Migrations
{
    public partial class ChangeGameTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.CreateTable(
                name: "GameIdsFromMongo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<string>(name: "Game Id", type: "text", nullable: false),
                    UserIdNavigationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameIdsFromMongo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameIdsFromMongo_Users_UserIdNavigationId",
                        column: x => x.UserIdNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameIdsFromMongo_Game Id",
                table: "GameIdsFromMongo",
                column: "Game Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameIdsFromMongo_UserIdNavigationId",
                table: "GameIdsFromMongo",
                column: "UserIdNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameIdsFromMongo");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<string>(name: "Game Id", type: "text", nullable: false),
                    UserIdNavigationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Users_UserIdNavigationId",
                        column: x => x.UserIdNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Game Id",
                table: "Games",
                column: "Game Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserIdNavigationId",
                table: "Games",
                column: "UserIdNavigationId");
        }
    }
}

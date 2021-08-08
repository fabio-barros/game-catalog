using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UserDataApp.Migrations
{
    public partial class GameService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameIdsFromMongo");

            migrationBuilder.CreateTable(
                name: "GameInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<string>(name: "Game Id", type: "text", nullable: false),
                    UserIdNavigationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameInfo_Users_UserIdNavigationId",
                        column: x => x.UserIdNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameInfo_Game Id",
                table: "GameInfo",
                column: "Game Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameInfo_UserIdNavigationId",
                table: "GameInfo",
                column: "UserIdNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameInfo");

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
    }
}

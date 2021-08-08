using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserDataApp.Migrations
{
    public partial class GameForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_Id",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Games");

            migrationBuilder.AddColumn<Guid>(
                name: "UserIdNavigationId",
                table: "Games",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Game Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserIdNavigationId",
                table: "Games",
                column: "UserIdNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserIdNavigationId",
                table: "Games",
                column: "UserIdNavigationId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserIdNavigationId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserIdNavigationId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserIdNavigationId",
                table: "Games");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Games",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_Id",
                table: "Games",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

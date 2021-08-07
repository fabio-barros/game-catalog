using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserDataApp.Migrations
{
    public partial class RelationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_User Id",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_User Id",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "User Id",
                table: "Games");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Games",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Games");

            migrationBuilder.AddColumn<Guid>(
                name: "User Id",
                table: "Games",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Games_User Id",
                table: "Games",
                column: "User Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_User Id",
                table: "Games",
                column: "User Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

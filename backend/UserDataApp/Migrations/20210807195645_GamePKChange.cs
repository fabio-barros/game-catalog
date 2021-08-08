﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UserDataApp.Migrations
{
    public partial class GamePKChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Game Id");
        }
    }
}

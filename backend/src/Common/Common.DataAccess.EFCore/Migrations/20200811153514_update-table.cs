using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeEnd",
                schema: "project",
                table: "GameShows");

            migrationBuilder.DropColumn(
                name: "TimeNext",
                schema: "project",
                table: "GameShows");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                schema: "project",
                table: "GameShows");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                schema: "project",
                table: "UserGameShows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "project",
                table: "GameShows",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                schema: "project",
                table: "GameShows",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                schema: "project",
                table: "GameShows");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                schema: "project",
                table: "GameShows",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeEnd",
                schema: "project",
                table: "GameShows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimeNext",
                schema: "project",
                table: "GameShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStart",
                schema: "project",
                table: "GameShows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class fixquestion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameShows_Users_UserId",
                schema: "project",
                table: "GameShows");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                schema: "project",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "project",
                table: "GameShows");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "project",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "project",
                table: "GameShows",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                schema: "project",
                table: "GameShows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_GameShows_Users_UserId",
                schema: "project",
                table: "GameShows",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                schema: "project",
                table: "Questions",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameShows_Users_UserId",
                schema: "project",
                table: "GameShows");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                schema: "project",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "project",
                table: "GameShows");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "project",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "project",
                table: "GameShows",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "project",
                table: "GameShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_GameShows_Users_UserId",
                schema: "project",
                table: "GameShows",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserId",
                schema: "project",
                table: "Questions",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

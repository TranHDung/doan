using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class updateGameShowTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                schema: "project",
                table: "GameShows",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "project",
                table: "GameShows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameShows_UserId",
                schema: "project",
                table: "GameShows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameShows_Users_UserId",
                schema: "project",
                table: "GameShows",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameShows_Users_UserId",
                schema: "project",
                table: "GameShows");

            migrationBuilder.DropIndex(
                name: "IX_GameShows_UserId",
                schema: "project",
                table: "GameShows");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                schema: "project",
                table: "GameShows");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "project",
                table: "GameShows");
        }
    }
}

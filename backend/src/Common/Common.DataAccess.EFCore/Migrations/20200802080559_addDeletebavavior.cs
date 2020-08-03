using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class addDeletebavavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionGameShows_GameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionGameShows_GameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows",
                column: "GameshowId",
                principalSchema: "project",
                principalTable: "GameShows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionGameShows_GameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionGameShows_GameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows",
                column: "GameshowId",
                principalSchema: "project",
                principalTable: "GameShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

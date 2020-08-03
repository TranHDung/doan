using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class removetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionGameShows_GameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionGameShows_Questions_QuestionId",
                schema: "project",
                table: "QuestionGameShows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.DropIndex(
                name: "IX_QuestionGameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows");

            migrationBuilder.DropIndex(
                name: "IX_QuestionGameShows_QuestionId",
                schema: "project",
                table: "QuestionGameShows");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionGameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows",
                column: "GameshowId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionGameShows_QuestionId",
                schema: "project",
                table: "QuestionGameShows",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionGameShows_GameShows_GameshowId",
                schema: "project",
                table: "QuestionGameShows",
                column: "GameshowId",
                principalSchema: "project",
                principalTable: "GameShows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionGameShows_Questions_QuestionId",
                schema: "project",
                table: "QuestionGameShows",
                column: "QuestionId",
                principalSchema: "project",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

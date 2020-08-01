using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class addUserGameShowTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShow_GameShows_GameshowId",
                schema: "project",
                table: "UserGameShow");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShow_Users_UserId",
                schema: "project",
                table: "UserGameShow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGameShow",
                schema: "project",
                table: "UserGameShow");

            migrationBuilder.RenameTable(
                name: "UserGameShow",
                schema: "project",
                newName: "UserGameShows",
                newSchema: "project");

            migrationBuilder.RenameIndex(
                name: "IX_UserGameShow_UserId",
                schema: "project",
                table: "UserGameShows",
                newName: "IX_UserGameShows_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGameShow_GameshowId",
                schema: "project",
                table: "UserGameShows",
                newName: "IX_UserGameShows_GameshowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGameShows",
                schema: "project",
                table: "UserGameShows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameShows_GameShows_GameshowId",
                schema: "project",
                table: "UserGameShows",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShows_GameShows_GameshowId",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGameShows_Users_UserId",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGameShows",
                schema: "project",
                table: "UserGameShows");

            migrationBuilder.RenameTable(
                name: "UserGameShows",
                schema: "project",
                newName: "UserGameShow",
                newSchema: "project");

            migrationBuilder.RenameIndex(
                name: "IX_UserGameShows_UserId",
                schema: "project",
                table: "UserGameShow",
                newName: "IX_UserGameShow_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGameShows_GameshowId",
                schema: "project",
                table: "UserGameShow",
                newName: "IX_UserGameShow_GameshowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGameShow",
                schema: "project",
                table: "UserGameShow",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameShow_GameShows_GameshowId",
                schema: "project",
                table: "UserGameShow",
                column: "GameshowId",
                principalSchema: "project",
                principalTable: "GameShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameShow_Users_UserId",
                schema: "project",
                table: "UserGameShow",
                column: "UserId",
                principalSchema: "project",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class fixtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_GameShows_GameShowId",
                schema: "project",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_GameShowId",
                schema: "project",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "GameShowId",
                schema: "project",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameShowId",
                schema: "project",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GameShowId",
                schema: "project",
                table: "Questions",
                column: "GameShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_GameShows_GameShowId",
                schema: "project",
                table: "Questions",
                column: "GameShowId",
                principalSchema: "project",
                principalTable: "GameShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

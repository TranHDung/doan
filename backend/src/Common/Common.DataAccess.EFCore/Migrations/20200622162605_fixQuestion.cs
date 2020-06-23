using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class fixQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_GameShows_GameShowId",
                schema: "project",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "GameShowId",
                schema: "project",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_GameShows_GameShowId",
                schema: "project",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "GameShowId",
                schema: "project",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_GameShows_GameShowId",
                schema: "project",
                table: "Questions",
                column: "GameShowId",
                principalSchema: "project",
                principalTable: "GameShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

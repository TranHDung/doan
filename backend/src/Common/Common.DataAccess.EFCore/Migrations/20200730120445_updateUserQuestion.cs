using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class updateUserQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "project",
                table: "Questions",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                schema: "project",
                table: "Questions",
                column: "UserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserId",
                schema: "project",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId",
                schema: "project",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "project",
                table: "Questions");
        }
    }
}

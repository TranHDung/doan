using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class addQuestionGameshowTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "project",
                table: "GameShows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuestionGameShows",
                schema: "project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false),
                    GameshowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionGameShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionGameShows_GameShows_GameshowId",
                        column: x => x.GameshowId,
                        principalSchema: "project",
                        principalTable: "GameShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionGameShows_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "project",
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionGameShows",
                schema: "project");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "project",
                table: "GameShows");
        }
    }
}

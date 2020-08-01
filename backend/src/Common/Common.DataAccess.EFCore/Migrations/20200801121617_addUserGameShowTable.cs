using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class addUserGameShowTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserGameShow",
                schema: "project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsOnline = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    GameshowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGameShow_GameShows_GameshowId",
                        column: x => x.GameshowId,
                        principalSchema: "project",
                        principalTable: "GameShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameShow_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "project",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGameShow_GameshowId",
                schema: "project",
                table: "UserGameShow",
                column: "GameshowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameShow_UserId",
                schema: "project",
                table: "UserGameShow",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGameShow",
                schema: "project");
        }
    }
}

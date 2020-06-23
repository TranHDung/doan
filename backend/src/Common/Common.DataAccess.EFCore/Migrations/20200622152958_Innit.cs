using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.DataAccess.EFCore.Migrations
{
    public partial class Innit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEmails",
                schema: "lottery");

            migrationBuilder.DropTable(
                name: "WonCodes",
                schema: "lottery");

            migrationBuilder.DropTable(
                name: "Codes",
                schema: "lottery");

            migrationBuilder.DropTable(
                name: "HotspotResults",
                schema: "lottery");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "lottery");

            migrationBuilder.EnsureSchema(
                name: "project");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "lottery",
                newName: "Users",
                newSchema: "project");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "lottery",
                newName: "UserRoles",
                newSchema: "project");

            migrationBuilder.RenameTable(
                name: "UserPhotos",
                schema: "lottery",
                newName: "UserPhotos",
                newSchema: "project");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "lottery",
                newName: "UserClaims",
                newSchema: "project");

            migrationBuilder.RenameTable(
                name: "Settings",
                schema: "lottery",
                newName: "Settings",
                newSchema: "project");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "lottery",
                newName: "Roles",
                newSchema: "project");

            migrationBuilder.CreateTable(
                name: "GameShows",
                schema: "project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    TimeNext = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AnswerA = table.Column<string>(nullable: true),
                    AnswerB = table.Column<string>(nullable: true),
                    AnswerC = table.Column<string>(nullable: true),
                    AnswerD = table.Column<string>(nullable: true),
                    RightAnswer = table.Column<int>(nullable: false),
                    GameShowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_GameShows_GameShowId",
                        column: x => x.GameShowId,
                        principalSchema: "project",
                        principalTable: "GameShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responds",
                schema: "project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    GameShowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responds_GameShows_GameShowId",
                        column: x => x.GameShowId,
                        principalSchema: "project",
                        principalTable: "GameShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responds_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "project",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GameShowId",
                schema: "project",
                table: "Questions",
                column: "GameShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Responds_GameShowId",
                schema: "project",
                table: "Responds",
                column: "GameShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Responds_UserId",
                schema: "project",
                table: "Responds",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions",
                schema: "project");

            migrationBuilder.DropTable(
                name: "Responds",
                schema: "project");

            migrationBuilder.DropTable(
                name: "GameShows",
                schema: "project");

            migrationBuilder.EnsureSchema(
                name: "lottery");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "project",
                newName: "Users",
                newSchema: "lottery");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "project",
                newName: "UserRoles",
                newSchema: "lottery");

            migrationBuilder.RenameTable(
                name: "UserPhotos",
                schema: "project",
                newName: "UserPhotos",
                newSchema: "lottery");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "project",
                newName: "UserClaims",
                newSchema: "lottery");

            migrationBuilder.RenameTable(
                name: "Settings",
                schema: "project",
                newName: "Settings",
                newSchema: "lottery");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "project",
                newName: "Roles",
                newSchema: "lottery");

            migrationBuilder.CreateTable(
                name: "GroupEmails",
                schema: "lottery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Emails = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEmails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "lottery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotspotResults",
                schema: "lottery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlueString = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrawNumber = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YellowNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotspotResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Codes",
                schema: "lottery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    IsAlert = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NotAppeareCount = table.Column<int>(type: "int", nullable: false),
                    NumbersString = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReappeareCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Codes_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "lottery",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WonCodes",
                schema: "lottery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deficit = table.Column<int>(type: "int", nullable: false),
                    HotspotResultId = table.Column<int>(type: "int", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WonCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WonCodes_Codes_CodeId",
                        column: x => x.CodeId,
                        principalSchema: "lottery",
                        principalTable: "Codes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WonCodes_HotspotResults_HotspotResultId",
                        column: x => x.HotspotResultId,
                        principalSchema: "lottery",
                        principalTable: "HotspotResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Codes_GroupId",
                schema: "lottery",
                table: "Codes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WonCodes_CodeId",
                schema: "lottery",
                table: "WonCodes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WonCodes_HotspotResultId",
                schema: "lottery",
                table: "WonCodes",
                column: "HotspotResultId");
        }
    }
}

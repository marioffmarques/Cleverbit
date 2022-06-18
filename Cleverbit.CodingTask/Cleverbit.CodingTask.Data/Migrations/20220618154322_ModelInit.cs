using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cleverbit.CodingTask.Data.Migrations
{
    public partial class ModelInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_MatchType_MatchTypeId",
                        column: x => x.MatchTypeId,
                        principalTable: "MatchType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserMatch",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMatch", x => new { x.MatchId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMatch_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMatch_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatchTypeId",
                table: "Match",
                column: "MatchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMatch_UserId",
                table: "UserMatch",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMatch");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "MatchType");
        }
    }
}

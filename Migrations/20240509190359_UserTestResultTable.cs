using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace programming_skills_assessment_backend.Migrations
{
    /// <inheritdoc />
    public partial class UserTestResultTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fe98a99-29b8-421b-9a04-10bf306acfec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ac7bf9b-ee62-4318-8e59-db03bfba4f2d");

            migrationBuilder.CreateTable(
                name: "UserTestResults",
                columns: table => new
                {
                    UserTestResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDurationTimer = table.Column<int>(type: "int", nullable: false),
                    RemainingDurationTimer = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestResults", x => x.UserTestResultID);
                    table.ForeignKey(
                        name: "FK_UserTestResults_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionResult",
                columns: table => new
                {
                    QuestionResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTestResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResult", x => x.QuestionResultID);
                    table.ForeignKey(
                        name: "FK_QuestionResult_UserTestResults_UserTestResultID",
                        column: x => x.UserTestResultID,
                        principalTable: "UserTestResults",
                        principalColumn: "UserTestResultID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b0862f6-5a5b-4fd4-8bd7-2b78042128bf", null, "User", "USER" },
                    { "baae0d5e-2f61-491f-80fe-dba0ca13e8cd", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResult_UserTestResultID",
                table: "QuestionResult",
                column: "UserTestResultID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestResults_UserID",
                table: "UserTestResults",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionResult");

            migrationBuilder.DropTable(
                name: "UserTestResults");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b0862f6-5a5b-4fd4-8bd7-2b78042128bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baae0d5e-2f61-491f-80fe-dba0ca13e8cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fe98a99-29b8-421b-9a04-10bf306acfec", null, "Admin", "ADMIN" },
                    { "9ac7bf9b-ee62-4318-8e59-db03bfba4f2d", null, "User", "USER" }
                });
        }
    }
}

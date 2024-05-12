using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace programming_skills_assessment_backend.Migrations
{
    /// <inheritdoc />
    public partial class UserTestResultTestID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b0862f6-5a5b-4fd4-8bd7-2b78042128bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baae0d5e-2f61-491f-80fe-dba0ca13e8cd");

            migrationBuilder.AddColumn<Guid>(
                name: "TestID",
                table: "UserTestResults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "185b3b26-5ce6-4e2f-8207-615be47738e9", null, "Admin", "ADMIN" },
                    { "661b4856-15e3-4ecc-b877-cad86ae70a14", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "185b3b26-5ce6-4e2f-8207-615be47738e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661b4856-15e3-4ecc-b877-cad86ae70a14");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "UserTestResults");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b0862f6-5a5b-4fd4-8bd7-2b78042128bf", null, "User", "USER" },
                    { "baae0d5e-2f61-491f-80fe-dba0ca13e8cd", null, "Admin", "ADMIN" }
                });
        }
    }
}

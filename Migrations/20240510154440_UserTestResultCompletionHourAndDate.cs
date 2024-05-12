using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace programming_skills_assessment_backend.Migrations
{
    /// <inheritdoc />
    public partial class UserTestResultCompletionHourAndDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63aa384e-6afd-408b-8a49-9f394e1c66b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fb3dac3-3bae-4380-8034-a46214fc40e0");

            migrationBuilder.AddColumn<string>(
                name: "CompletionDate",
                table: "UserTestResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompletionHour",
                table: "UserTestResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8633b922-0436-4fdd-b668-fa6e10ba1a54", null, "Admin", "ADMIN" },
                    { "ce18f7d4-8847-4ca9-a2b8-68536bbe6080", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8633b922-0436-4fdd-b668-fa6e10ba1a54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce18f7d4-8847-4ca9-a2b8-68536bbe6080");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "UserTestResults");

            migrationBuilder.DropColumn(
                name: "CompletionHour",
                table: "UserTestResults");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63aa384e-6afd-408b-8a49-9f394e1c66b6", null, "Admin", "ADMIN" },
                    { "9fb3dac3-3bae-4380-8034-a46214fc40e0", null, "User", "USER" }
                });
        }
    }
}

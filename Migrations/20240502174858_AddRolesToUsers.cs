using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace programming_skills_assessment_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0702143f-a164-48a7-9637-0ae43efba159", null, "Administrator", "ADMINISTRATOR" },
                    { "45ee19cd-bc60-4eae-babc-45bc163c9522", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0702143f-a164-48a7-9637-0ae43efba159");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45ee19cd-bc60-4eae-babc-45bc163c9522");
        }
    }
}

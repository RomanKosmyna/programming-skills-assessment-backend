using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace programming_skills_assessment_backend.Migrations
{
    /// <inheritdoc />
    public partial class QuestionResultUserTestResultNavProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResult_UserTestResults_UserTestResultID",
                table: "QuestionResult");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "185b3b26-5ce6-4e2f-8207-615be47738e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "661b4856-15e3-4ecc-b877-cad86ae70a14");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserTestResultID",
                table: "QuestionResult",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63aa384e-6afd-408b-8a49-9f394e1c66b6", null, "Admin", "ADMIN" },
                    { "9fb3dac3-3bae-4380-8034-a46214fc40e0", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResult_UserTestResults_UserTestResultID",
                table: "QuestionResult",
                column: "UserTestResultID",
                principalTable: "UserTestResults",
                principalColumn: "UserTestResultID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResult_UserTestResults_UserTestResultID",
                table: "QuestionResult");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63aa384e-6afd-408b-8a49-9f394e1c66b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fb3dac3-3bae-4380-8034-a46214fc40e0");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserTestResultID",
                table: "QuestionResult",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "185b3b26-5ce6-4e2f-8207-615be47738e9", null, "Admin", "ADMIN" },
                    { "661b4856-15e3-4ecc-b877-cad86ae70a14", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResult_UserTestResults_UserTestResultID",
                table: "QuestionResult",
                column: "UserTestResultID",
                principalTable: "UserTestResults",
                principalColumn: "UserTestResultID");
        }
    }
}

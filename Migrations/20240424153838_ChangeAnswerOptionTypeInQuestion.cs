using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace programming_skills_assessment_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAnswerOptionTypeInQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerOptions",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerOptions_QuestionID",
                table: "AnswerOptions",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionID",
                table: "AnswerOptions",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionID",
                table: "AnswerOptions");

            migrationBuilder.DropIndex(
                name: "IX_AnswerOptions_QuestionID",
                table: "AnswerOptions");

            migrationBuilder.AddColumn<string>(
                name: "AnswerOptions",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

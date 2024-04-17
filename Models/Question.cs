using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_skills_assessment_backend.Models;

[Table("Questions")]
public class Question
{
    public Guid QuestionID { get; set; }
    public Guid TestID { get; set; }
    [Required]
    public int QuestionNumber { get; set; }
    [Required]
    public string QuestionText { get; set; } = string.Empty;
    public List<string>? AnswerOptions { get; set; }
    public List<int>? CorrectAnswer { get; set; }
    public string? Image {  get; set; }

    // navigation prop
    public Test? Test { get; set; }
}

namespace programming_skills_assessment_backend.Dtos.QuestionDtos;

public class QuestionDto
{
    public Guid QuestionID { get; set; }
    public int QuestionNumber { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public List<Models.AnswerOption> AnswerOptions { get; set; } = [];
    public string? Image { get; set; }

    public Guid TestID { get; set; }
}
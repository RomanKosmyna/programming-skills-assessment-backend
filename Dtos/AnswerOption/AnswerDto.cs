namespace programming_skills_assessment_backend.Dtos.AnswerOption;

public class AnswerDto
{
    public Guid QuestionID { get; set; }
    public int QuestionNumber { get; set; }
    public bool IsCorrect { get; set; }
}

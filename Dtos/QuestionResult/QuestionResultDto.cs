namespace programming_skills_assessment_backend.Dtos.QuestionResult;

public class QuestionResultDto
{
    public Guid QuestionResultID { get; set; }
    public bool IsCorrect { get; set; }
    public Guid QuestionID { get; set; }
}

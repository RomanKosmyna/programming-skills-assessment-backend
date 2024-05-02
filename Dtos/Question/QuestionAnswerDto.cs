namespace programming_skills_assessment_backend.Dtos.Question;

public class QuestionAnswerDto
{
    public Guid QuestionID { get; set; }
    public List<int>? AnswerOptions { get; set; }
}

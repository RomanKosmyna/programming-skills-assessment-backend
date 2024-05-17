namespace programming_skills_assessment_backend.Dtos.Question;

public class RelatedTableQuestionDto
{
    public Guid QuestionID { get; set; }
    public int QuestionNumber { get; set; }
    public List<int>? CorrectAnswer { get; set; }
}

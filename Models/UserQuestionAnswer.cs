namespace programming_skills_assessment_backend.Models;

public class UserQuestionAnswer
{
    public Guid QuestionID { get; set; }
    public List<int> ArrayOfAnswers { get; set; }
}

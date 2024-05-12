namespace programming_skills_assessment_backend.Models;

public class QuestionResult
{
    public Guid QuestionResultID { get; set; }
    public bool IsCorrect { get; set; }
    public Guid QuestionID { get; set; }
    public Guid UserTestResultID { get; set; }
    public UserTestResult? UserTestResult { get; set; }
}

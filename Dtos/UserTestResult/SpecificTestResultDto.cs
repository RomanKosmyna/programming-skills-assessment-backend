using programming_skills_assessment_backend.Dtos.QuestionResult;

namespace programming_skills_assessment_backend.Dtos.UserTestResult;

public class SpecificTestResultDto
{
    public Guid UserTestResultID { get; set; }
    public Guid TestCategoryID { get; set; }
    public string TestName { get; set; }
    public List<QuestionResultDto?> QuestionData { get; set; }
    public int TotalDurationTimer { get; set; }
    public int RemainingDurationTimer { get; set; }
    public string CompletionHour { get; set; }
    public string CompletionDate { get; set; }
}

using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Dtos.UserTestResult;

public class UserTestResultDto
{
    public Guid UserTestResultID { get; set; }
    public Guid TestCategoryID { get; set; }
    public string TestName { get; set; }
    public int TotalDurationTimer { get; set; }
    public int RemainingDurationTimer { get; set; }
}

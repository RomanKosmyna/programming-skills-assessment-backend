using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_skills_assessment_backend.Models;

[Table("UserTestResults")]
public class UserTestResult
{
    public Guid UserTestResultID { get; set; }
    public Guid TestCategoryID { get; set; }
    public string TestName { get; set; }
    public List<QuestionResult?> QuestionData {  get; set; }
    public int TotalDurationTimer { get; set; }
    public int RemainingDurationTimer { get; set; }
    public string CompletionHour { get; set; }
    public string CompletionDate { get; set; }
    public Guid TestID { get; set; }
    public string UserID { get; set; }
    public AppUser? User { get; set; }
}
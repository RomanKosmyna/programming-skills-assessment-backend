using programming_skills_assessment_backend.Models;
using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.TestDto;

public class TestDto
{
    public Guid TestID { get; set; }
    public Guid TestTypeID { get; set; }
    public TestType? TestType { get; set; }
    [Required]
    public string TestName { get; set; } = string.Empty;
    [Required]
    public List<Models.Question>? Questions { get; set; }
    public int? DurationMinutes { get; set; }
}

using programming_skills_assessment_backend.Dtos.QuestionDtos;
using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.TestDto;

public class TestDto
{
    public Guid TestID { get; set; }
    public Guid TestCategoryID { get; set; }
    [Required]
    public string TestName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? DurationMinutes { get; set; }
    public List<string>? TestedSkills { get; set; }
}

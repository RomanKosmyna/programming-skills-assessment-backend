using programming_skills_assessment_backend.Dtos.QuestionDtos;
using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.TestDto;

public class TestDto
{
    public Guid TestID { get; set; }
    public Guid TestTypeID { get; set; }
    [Required]
    public string TestName { get; set; } = string.Empty;
    [Required]
    public List<QuestionDto>? Questions { get; set; }
    public List<string>? TestedSkills { get; set; }
    public int? DurationMinutes { get; set; }
}

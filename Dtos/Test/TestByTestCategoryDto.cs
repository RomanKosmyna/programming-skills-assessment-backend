using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.Test;

public class TestByTestCategoryDto
{
    public Guid TestID { get; set; }
    public Guid TestCategoryID { get; set; }
    [Required]
    public string TestName { get; set; }
    public List<string>? TestedSkills { get; set; }
    public int? DurationMinutes { get; set; }
}

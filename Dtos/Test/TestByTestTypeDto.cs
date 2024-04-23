using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.Test;

public class TestByTestTypeDto
{
    public Guid TestID { get; set; }
    public Guid TestTypeID { get; set; }
    [Required]
    public string TestName { get; set; } = string.Empty;
    public int? DurationMinutes { get; set; }
}

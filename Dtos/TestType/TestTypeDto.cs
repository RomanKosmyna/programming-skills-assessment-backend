using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.TestTypeDto;

public class TestTypeDto
{
    public Guid TestTypeID { get; set; }
    [Required]
    public string TestTypeName { get; set; } = string.Empty;

    public List<Models.Test> Tests { get; set; } = [];
}

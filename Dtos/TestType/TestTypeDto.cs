using programming_skills_assessment_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace programming_skills_assessment_backend.Dtos.TestTypeDto;

public class TestTypeDto
{
    public Guid TestTypeID { get; set; }
    [Required]
    public string TestTypeName { get; set; } = string.Empty;

    public List<Test> Tests { get; set; } = [];
}

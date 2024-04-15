using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace programming_skills_assessment_backend.Models;

[Table("Tests")]
public class Test
{
    public Guid TestID { get; set; }
    public Guid TestTypeID { get; set; }
    // navigation prop
    public TestType? TestType { get; set; }
    [Required]
    public string TestName { get; set; } = string.Empty;
    [Required]
    // navigation prop
    public List<Question>? Questions { get; set; }
    public int? DurationMinutes { get; set; }
}

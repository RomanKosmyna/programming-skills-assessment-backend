using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_skills_assessment_backend.Models;

[Table("Tests")]
public class Test
{
    public Guid TestID { get; set; }
    [Required]
    public string TestName { get; set; } = string.Empty;
    public List<string>? TestedSkills { get; set; }
    [Required]
    public int? DurationMinutes { get; set; }

    // navigation prop
    public Guid TestTypeID { get; set; }
    public TestType? TestType { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
}

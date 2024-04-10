using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_skills_assessment_backend.Models;

[Table("TestTypes")]
public class TestType
{
    public Guid TestTypeID { get; set; }
    [Required]
    public string TestTypeName { get; set; } = string.Empty;
    // navigation prop
    public List<Test> Tests {  get; set; } = [];
}

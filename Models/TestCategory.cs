using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_skills_assessment_backend.Models;

[Table("TestCategories")]
public class TestCategory
{
    public Guid TestCategoryID { get; set; }
    [Required]
    public string TestCategoryName { get; set; } = string.Empty;
    public List<Test> Tests {  get; set; } = [];
}
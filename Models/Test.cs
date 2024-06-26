﻿using System.ComponentModel.DataAnnotations;
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
    public string Description { get; set; } = string.Empty;
    [Required]
    public int? DurationMinutes { get; set; }
    public Guid TestCategoryID { get; set; }
    public TestCategory? TestCategory { get; set; }
    public List<Question> Questions { get; set; }
}

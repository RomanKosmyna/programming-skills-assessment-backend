using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_skills_assessment_backend.Models;

[Table("AnswerOptions")]
public class AnswerOption
{
    public Guid AnswerOptionID { get; set; }
    public Guid QuestionID { get; set; }
    [Required]
    public int OptionNumber { get; set; }
    [Required]
    public string OptionText { get; set; }
}

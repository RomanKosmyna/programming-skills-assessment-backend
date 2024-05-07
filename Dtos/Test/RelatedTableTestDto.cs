using programming_skills_assessment_backend.Dtos.Question;

namespace programming_skills_assessment_backend.Dtos.Test;

public class RelatedTableTestDto
{
    public Guid TestID { get; set; }
    public string TestName { get; set; } = string.Empty;
    //public List<string>? TestedSkills { get; set; }
    //public string Description { get; set; } = string.Empty;
    //public int? DurationMinutes { get; set; }

    //public Guid TestCategoryID { get; set; }
    public List<RelatedTableQuestionDto> Questions { get; set; }
}

using programming_skills_assessment_backend.Dtos.Question;

namespace programming_skills_assessment_backend.Dtos.Test;

public class RelatedTableTestDto
{
    public Guid TestID { get; set; }
    public string TestName { get; set; } = string.Empty;
    public List<RelatedTableQuestionDto> Questions { get; set; }
}

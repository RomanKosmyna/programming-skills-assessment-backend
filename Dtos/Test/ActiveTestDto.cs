using programming_skills_assessment_backend.Dtos.QuestionDtos;

namespace programming_skills_assessment_backend.Dtos.Test;

public class ActiveTestDto
{
    public Guid TestID { get; set; }
    public Guid TestTypeID { get; set; }
    public string TestName { get; set; }
    public List<QuestionDto> Questions { get; set; }
    public string Description { get; set; }
    public int? DurationMinutes { get; set; }
    public List<string>? TestedSkills { get; set; }
}

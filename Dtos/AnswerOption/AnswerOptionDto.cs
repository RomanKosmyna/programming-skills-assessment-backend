namespace programming_skills_assessment_backend.Dtos.AnswerOption;

public class AnswerOptionDto
{
    public Guid AnswerOptionID { get; set; }
    public int OptionNumber { get; set; }
    public string OptionText { get; set; } = string.Empty;

    public Guid QuestionID { get; set; }
}

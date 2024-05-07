namespace programming_skills_assessment_backend.Dtos.AnswerOption;

public class RelatedTableAnswerOptionDto
{
    public Guid AnswerOptionID { get; set; }
    public Guid QuestionID { get; set; }
    public int OptionNumber { get; set; }
    public string OptionText { get; set; }
}

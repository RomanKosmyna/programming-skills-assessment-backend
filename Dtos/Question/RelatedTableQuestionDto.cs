using programming_skills_assessment_backend.Dtos.AnswerOption;

namespace programming_skills_assessment_backend.Dtos.Question;

public class RelatedTableQuestionDto
{
    public Guid QuestionID { get; set; }
    //public Guid TestID { get; set; }
    public int QuestionNumber { get; set; }
    //public string QuestionText { get; set; }
    public List<int>? CorrectAnswer { get; set; }
    //public string? Image { get; set; }
    //public List<RelatedTableAnswerOptionDto> AnswerOptions { get; set; }
}

using programming_skills_assessment_backend.Dtos.TestResult;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestResultRepository
{
    Task<List<QuestionResultDto>?> ValidateAnswersAsync(Guid testID, List<UserQuestionAnswerDto> userQuestionAnswers);
}

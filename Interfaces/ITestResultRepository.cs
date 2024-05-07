using programming_skills_assessment_backend.Dtos.TestResult;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestResultRepository
{
    Task<List<QuestionResultDto>?> ValidateAnswers(Guid testID, List<UserQuestionAnswer> userQuestionAnswers);
}

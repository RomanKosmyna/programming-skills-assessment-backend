using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestResultRepository
{
    Task<Test?> ValidateAnswers(Guid testID, List<UserQuestionAnswer> userQuestionAnswers);
}

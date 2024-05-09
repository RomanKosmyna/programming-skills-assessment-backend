using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface IUserTestResultRepository
{
    Task<UserTestResult> SaveUserTestResult(UserTestResult userTestResult);
}

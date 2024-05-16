using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface IUserTestResultRepository
{
    Task<UserTestResult> SaveUserTestResultAsync(UserTestResult userTestResult);
    Task<List<UserTestResult>?> GetAllUserTestResultsAsync(string username);
    Task<UserTestResult?> GetUserTestResultByIdAsync(Guid userTestResultID);
    Task<UserTestResult?> DeleteUserTestResultAsync(Guid userTestResultID);
}

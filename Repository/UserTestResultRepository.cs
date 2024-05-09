using Microsoft.AspNetCore.Identity;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class UserTestResultRepository : IUserTestResultRepository
{
    private readonly ApplicationDBContext _dbContext;

    public UserTestResultRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserTestResult> SaveUserTestResult(UserTestResult userTestResult)
    {
        await _dbContext.UserTestResults.AddAsync(userTestResult);
        await _dbContext.SaveChangesAsync();

        return userTestResult;
    }
}

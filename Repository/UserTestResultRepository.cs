using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;


namespace programming_skills_assessment_backend.Repository;

public class UserTestResultRepository : IUserTestResultRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ApplicationDBContext _dbContext;

    public UserTestResultRepository(UserManager<AppUser> userManager, ApplicationDBContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task<UserTestResult> SaveUserTestResult(UserTestResult userTestResult)
    {
        await _dbContext.UserTestResults.AddAsync(userTestResult);
        await _dbContext.SaveChangesAsync();

        return userTestResult;
    }

    public async Task<List<UserTestResult>?> GetAllUserTestResults(string username)
    {
        var findUser = await _userManager.FindByNameAsync(username);

        if (findUser == null) return null;

        var allUserTestResults = await _dbContext.UserTestResults
            .Where(utr => utr.UserID == findUser.Id)
            .ToListAsync();

        return allUserTestResults;
    }

    public async Task<UserTestResult?> GetUserTestResultById(Guid userTestResultID)
    {
        var userTestResult = await _dbContext.UserTestResults
            .Include(utr => utr.QuestionData)
            .FirstOrDefaultAsync(utr => utr.UserTestResultID == userTestResultID);

        if (userTestResult == null) return null;

        return userTestResult;
    }
}

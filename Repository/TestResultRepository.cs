using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class TestResultRepository : ITestResultRepository
{
    private readonly ApplicationDBContext _dbContext;

    public TestResultRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Test?> ValidateAnswers(Guid testID, List<UserQuestionAnswer> userQuestionAnswers)
    {
        //var expectedTest = await _dbContext.Tests.FindAsync(testID);
        //Serilog.Log.Information("{@expectedTest}", expectedTest);
        //if (expectedTest == null) return null;

        var test = await _dbContext.Tests
            .Include(test => test.Questions)
            .FirstOrDefaultAsync(test => test.TestID == testID);
        //var test = await _dbContext.Tests
        //.Include(test => test.Questions)
        ////.ThenInclude(q => q.AnswerOptions)
        ////.AsSplitQuery()
        //.FirstOrDefaultAsync(test => test.TestID == testID);
        //.FirstOrDefaultAsync(test => test.TestID == testID);
        if (test == null) return null;

        Serilog.Log.Information("{@test}", test);

        return test;
    }
}

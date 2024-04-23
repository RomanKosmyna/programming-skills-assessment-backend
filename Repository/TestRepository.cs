using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class TestRepository: ITestRepository
{
    private readonly ApplicationDBContext _dbContext;

    public TestRepository(ApplicationDBContext context)
    {
        _dbContext = context;
    }

    public async Task<Test> CreateTestAsync(Test test)
    {
        await _dbContext.Tests.AddAsync(test);
        await _dbContext.SaveChangesAsync();

        return test;
    }

    public async Task<List<Test>> GetAllTestsAsync()
    {
        var allTests = await _dbContext.Tests.ToListAsync();

        return allTests;
    }

    public async Task<Test?> GetTestByIdAsync(Guid id)
    {
        return await _dbContext.Tests.FindAsync(id) ?? null;
    }

    public async Task<Test?> GetTestByIdWithQuestionsAsync(Guid id)
    {
        var test = await _dbContext.Tests
            .Include(test => test.Questions)
            .FirstOrDefaultAsync(test => test.TestID == id);

        if (test == null) return null;

        return test;
    }

    public async Task<List<Test>?> GetTestsByTestTypeIdAsync(Guid id)
    {
        var expectedTestType = await _dbContext.TestTypes.FindAsync(id);

        if (expectedTestType == null) return null;

        var tests = await _dbContext.Tests.Where(t => t.TestTypeID == id).ToListAsync();

        return tests;
    }

    public async Task<Test?> UpdateTestAsync(Guid id, Test test)
    {
        var expectedTest = await _dbContext.Tests.FindAsync(id);

        if (expectedTest == null) return null;

        expectedTest.TestName = test.TestName;
        expectedTest.DurationMinutes = test.DurationMinutes;
        expectedTest.Questions = test.Questions;

        await _dbContext.SaveChangesAsync();

        return expectedTest;
    }

    public async Task<Test?> DeleteTestAsync(Guid id)
    {
        var expectedTest = await _dbContext.Tests.FindAsync(id);

        if (expectedTest == null) return null;

        _dbContext.Tests.Remove(expectedTest);
        await _dbContext.SaveChangesAsync();

        return expectedTest;
    }
}

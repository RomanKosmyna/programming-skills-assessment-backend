using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Dtos.AnswerOption;
using programming_skills_assessment_backend.Dtos.Question;
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

    public async Task<List<AnswerDto>?> CheckAnswers(Guid testID, List<QuestionAnswerDto> userAnswers)
    {
        var expectedTest = await _dbContext.Tests.FindAsync(testID);

        if (expectedTest == null) return null;

        List<AnswerDto> answers = [];

        foreach (var questions in expectedTest.Questions)
        {
           Console.WriteLine(questions);
        }
        return answers;
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

    public async Task<Test?> GetTestByIdWithRelatedTablesAsync(Guid id)
    {
        var test = await _dbContext.Tests
            .Include(test => test.Questions)
            .ThenInclude(question => question.AnswerOptions)
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
        expectedTest.TestedSkills = test.TestedSkills;
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

using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class TestTypeRepository : ITestTypeRepository
{
    private readonly ApplicationDBContext _dbContext;

    public TestTypeRepository(ApplicationDBContext context)
    {
        _dbContext = context;
    }

    public async Task<TestType> CreateTestTypeAsync(TestType testType)
    {
        await _dbContext.TestTypes.AddAsync(testType);
        await _dbContext.SaveChangesAsync();

        return testType;
    }

    public async Task<List<TestType>> GetAllTestTypesAsync()
    {
        var testTypes = await _dbContext.TestTypes.ToListAsync();

        return testTypes;
    }

    public async Task<TestType?> GetTestTypeByIdAsync(Guid id)
    {
        return await _dbContext.TestTypes.FindAsync(id) ?? null;
    }

    public async Task<List<Test>?> GetTestsByTestTypeIdAsync(Guid id)
    {
        var expectedTestType = await _dbContext.TestTypes.FindAsync(id);

        if (expectedTestType == null) return null;

        var tests = await _dbContext.Tests.Where(t => t.TestTypeID == id).ToListAsync();

        return tests;
    }

    public async Task<TestType?> DeleteTestTypeAsync(Guid id)
    {
        var expectedTestType = await _dbContext.TestTypes.FindAsync(id);

        if (expectedTestType == null) return null;

        _dbContext.TestTypes.Remove(expectedTestType);
        await _dbContext.SaveChangesAsync();

        return expectedTestType;
    }
}

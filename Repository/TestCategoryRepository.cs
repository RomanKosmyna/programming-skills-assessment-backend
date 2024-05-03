using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class TestCategoryRepository : ITestCategoryRepository
{
    private readonly ApplicationDBContext _dbContext;

    public TestCategoryRepository(ApplicationDBContext context)
    {
        _dbContext = context;
    }

    public async Task<TestCategory> CreateTestCategoryAsync(TestCategory testCategory)
    {
        await _dbContext.TestCategories.AddAsync(testCategory);
        await _dbContext.SaveChangesAsync();

        return testCategory;
    }

    public async Task<List<TestCategory>> GetAllTestCategoriesAsync()
    {
        var testCategories = await _dbContext.TestCategories.ToListAsync();

        return testCategories;
    }

    public async Task<TestCategory?> GetTestCategoryByIdAsync(Guid id)
    {
        return await _dbContext.TestCategories.FindAsync(id) ?? null;
    }

    public async Task<TestCategory?> DeleteTestCategoryAsync(Guid id)
    {
        var expectedTestCategory = await _dbContext.TestCategories.FindAsync(id);

        if (expectedTestCategory == null) return null;

        _dbContext.TestCategories.Remove(expectedTestCategory);
        await _dbContext.SaveChangesAsync();

        return expectedTestCategory;
    }
}

using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestCategoryRepository
{
    Task<TestCategory> CreateTestCategoryAsync(TestCategory testCategory);
    Task<List<TestCategory>> GetAllTestCategoriesAsync();
    Task<TestCategory?> GetTestCategoryByIdAsync(Guid id);
    Task<TestCategory?> DeleteTestCategoryAsync(Guid id);
}

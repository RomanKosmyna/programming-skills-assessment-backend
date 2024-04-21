using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestTypeRepository
{
    Task<TestType> CreateTestTypeAsync(TestType testType);
    Task<List<TestType>> GetAllTestTypesAsync();
    Task<TestType?> GetTestTypeByIdAsync(Guid id);
    Task<List<Test>?> GetTestsByTestTypeIdAsync(Guid id);
    Task<TestType?> DeleteTestTypeAsync(Guid id);
}

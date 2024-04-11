using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestTypeRepository
{
    Task<List<TestType>?> GetAllAsync();
    Task<TestType?> GetByIdAsync(Guid id);
    Task<TestType> CreateAsync(TestType testType);
    Task<TestType?> DeleteAsync(Guid id);
}

using programming_skills_assessment_backend.Dtos.TestType;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestTypeRepository
{
    Task<List<TestTypeDto>?> GetAllAsync();
    Task<TestTypeDto?> GetByIdAsync(Guid id);
    Task<TestTypeDto> CreateAsync(TestType testType);
    Task<TestTypeDto?> DeleteAsync(Guid id);
}

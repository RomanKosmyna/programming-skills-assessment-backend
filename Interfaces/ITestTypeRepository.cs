using programming_skills_assessment_backend.Dtos.TestTypeDto;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestTypeRepository
{
    Task<TestTypeDto> CreateAsync(TestType testType);
    Task<List<TestTypeDto>?> GetAllAsync();
    Task<TestTypeDto?> GetByIdAsync(Guid id);
    Task<TestTypeDto?> DeleteAsync(Guid id);
}

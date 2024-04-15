using Microsoft.AspNetCore.JsonPatch;
using programming_skills_assessment_backend.Dtos.TestDto;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestRepository
{
    Task<TestDto> CreateAsync(Test test);
    Task<List<TestDto>?> GetAllAsync();
    Task<Test?> GetByIdAsync(Guid id);
    Task<TestDto?> GetByIdWithQuestionsAsync(Guid id);
    Task<TestDto?> UpdateAsync(Guid id, JsonPatchDocument<Test> test);
    Task<TestDto?> DeleteAsync(Guid id);
}

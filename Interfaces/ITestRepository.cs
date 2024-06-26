﻿using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface ITestRepository
{
    Task<Test> CreateTestAsync(Test test);
    Task<List<Test>> GetAllTestsAsync();
    Task<Test?> GetTestByIdAsync(Guid id);
    Task<Test?> GetTestByIdWithRelatedDataAsync(Guid id);
    Task<List<Test>?> GetTestsByTestCategoryIdAsync(Guid id);
    Task<Test?> UpdateTestAsync(Guid id, Test test);
    Task<Test?> DeleteTestAsync(Guid id);
}
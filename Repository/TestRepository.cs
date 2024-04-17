using AutoMapper;
using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Dtos.TestDto;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class TestRepository: ITestRepository
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IMapper _mapper;

    public TestRepository(ApplicationDBContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public async Task<TestDto> CreateAsync(Test test)
    {
        await _dbContext.Tests.AddAsync(test);
        await _dbContext.SaveChangesAsync();

        var testDto = _mapper.Map<TestDto>(test);

        return testDto;
    }

    public async Task<List<TestDto>?> GetAllAsync()
    {
        var allTests = await _dbContext.Tests.ToListAsync();

        if (allTests == null) return null;

        var allTestsDto = allTests.Select(test => _mapper.Map<TestDto>(test)).ToList();

        return allTestsDto;
    }

    public async Task<Test?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Tests.FirstOrDefaultAsync(test => test.TestID == id);
    }

    public async Task<TestDto?> GetByIdWithQuestionsAsync(Guid id)
    {
        var test = await _dbContext.Tests
            .Include(test => test.Questions)
            .FirstOrDefaultAsync(test => test.TestID == id);

        if (test == null) return null;

        var testDto = _mapper.Map<TestDto>(test);

        return testDto;
    }

    public async Task<TestDto?> UpdateAsync(Guid id, Test test)
    {
        var existingTest = await GetByIdAsync(id);

        if (existingTest == null) return null;

        // testing purpose
        existingTest.DurationMinutes = test.DurationMinutes;
        //_mapper.Map(existingTest, test);
        _dbContext.Tests.Update(existingTest);

        await _dbContext.SaveChangesAsync();

        var updatedTestDto = _mapper.Map<TestDto>(existingTest);

        return updatedTestDto;
    }

    public async Task<TestDto?> DeleteAsync(Guid id)
    {
        var existingTest = await GetByIdAsync(id);

        if (existingTest == null) return null;

        _dbContext.Tests.Remove(existingTest);
        await _dbContext.SaveChangesAsync();

        var testDto = _mapper.Map<TestDto>(existingTest);

        return testDto;
    }
}

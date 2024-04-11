using AutoMapper;
using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Dtos.TestType;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class TestTypeRepository : ITestTypeRepository
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IMapper _mapper;

    public TestTypeRepository(ApplicationDBContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    public async Task<List<TestTypeDto>?> GetAllAsync()
    {
        var testTypes = await _dbContext.TestTypes.ToListAsync();

        if (testTypes == null) return null;

        var testTypeDto = testTypes.Select(t => _mapper.Map<TestTypeDto>(t)).ToList();

        return testTypeDto;
    }

    public async Task<TestType?> GetByIdAsync(Guid id)
    {
        return await _dbContext.TestTypes.Include(t => t.Tests).FirstOrDefaultAsync(t => t.TestTypeID == id);
    }

    public async Task<TestType> CreateAsync(TestType testType)
    {
        await _dbContext.TestTypes.AddAsync(testType);
        await _dbContext.SaveChangesAsync();

        return testType;
    }

    public async Task<TestType?> DeleteAsync(Guid id)
    {
        var testType = await _dbContext.TestTypes.FirstOrDefaultAsync(t => t.TestTypeID == id);

        if (testType == null) return null;

        _dbContext.TestTypes.Remove(testType);
        await _dbContext.SaveChangesAsync();

        return testType;
    }
}

using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class AnswerOptionRepository : IAnswerOptionRepository
{
    private readonly ApplicationDBContext _dbContext;

    public AnswerOptionRepository(ApplicationDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<AnswerOption> CreateAnswerOptionAsync(AnswerOption answerOption)
    {
        await _dbContext.AnswerOptions.AddAsync(answerOption);
        await _dbContext.SaveChangesAsync();

        return answerOption;
    }

    public async Task<List<AnswerOption>> GetAllAnswerOptionsAsync()
    {
        var allAnswerOptions = await _dbContext.AnswerOptions.ToListAsync();

        return allAnswerOptions;
    }

    public async Task<AnswerOption?> GetAnswerOptionByIdAsync(Guid id)
    {
        return await _dbContext.AnswerOptions.FindAsync(id) ?? null;
    }

    public async Task<AnswerOption?> UpdateAnswerOptionAsync(Guid id,  AnswerOption updatedAnswerOption)
    {
        var expectedAnswerOption = await _dbContext.AnswerOptions.FindAsync(id);

        if (expectedAnswerOption == null) return null;

        expectedAnswerOption.OptionNumber = updatedAnswerOption.OptionNumber;
        expectedAnswerOption.OptionText = updatedAnswerOption.OptionText;

        await _dbContext.SaveChangesAsync();

        return updatedAnswerOption;
    }

    public async Task<AnswerOption?> DeleteAnswerOptionAsync(Guid id)
    {
        var expectedAnswerOption = await _dbContext.AnswerOptions.FindAsync(id);

        if (expectedAnswerOption == null) return null;

        _dbContext.AnswerOptions.Remove(expectedAnswerOption);
        await _dbContext.SaveChangesAsync();

        return expectedAnswerOption;
    }
}

using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface IAnswerOptionRepository
{
    Task<AnswerOption> CreateAnswerOptionAsync(AnswerOption answerOption);
    Task<List<AnswerOption>> GetAllAnswerOptionsAsync();
    Task<AnswerOption?> GetAnswerOptionByIdAsync(Guid id);
    Task<AnswerOption?> UpdateAnswerOptionAsync(Guid id, AnswerOption updatedAnswerOption);
    Task<AnswerOption?> DeleteAnswerOptionAsync(Guid id);
}
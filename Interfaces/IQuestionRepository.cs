using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface IQuestionRepository
{
    Task<Question> CreateQuestionAsync(Question question);
    Task<List<Question>> GetAllQuestionsAsync();
    Task<Question?> GetQuestionByIdAsync(Guid id);
    Task<Question?> UpdateQuestionAsync(Guid id, Question question);
    Task<Question?> DeleteQuestionAsync(Guid id);
}

using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;


namespace programming_skills_assessment_backend.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly ApplicationDBContext _dbContext;

    public QuestionRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Question> CreateQuestionAsync(Question question)
    {
        await _dbContext.Questions.AddAsync(question);
        await _dbContext.SaveChangesAsync();

        return question;
    }

    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        var allQuestions = await _dbContext.Questions.ToListAsync();

        return allQuestions;
    }

    public async Task<Question?> GetQuestionByIdAsync(Guid id)
    {
        return await _dbContext.Questions.FindAsync(id) ?? null;
    }

    public async Task<Question?> UpdateQuestionAsync(Guid id, Question question)
    {
        var expectedQuestion = await _dbContext.Questions.FindAsync(id);

        if (expectedQuestion == null) return null;

        expectedQuestion.QuestionNumber = question.QuestionNumber;
        expectedQuestion.QuestionText = question.QuestionText;
        expectedQuestion.CorrectAnswer = question.CorrectAnswer;
        expectedQuestion.Image = question.Image;

        await _dbContext.SaveChangesAsync();

        return expectedQuestion;
    }

    public async Task<Question?> DeleteQuestionAsync(Guid id)
    {
        var expectedQuestion = await _dbContext.Questions.FindAsync(id);

        if (expectedQuestion == null) return null;

        _dbContext.Questions.Remove(expectedQuestion);
        await _dbContext.SaveChangesAsync();

        return expectedQuestion;
    }
}

using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Dtos.Question;
using programming_skills_assessment_backend.Dtos.Test;
using programming_skills_assessment_backend.Dtos.TestResult;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Repository;

public class TestResultRepository : ITestResultRepository
{
    private readonly ApplicationDBContext _dbContext;

    public TestResultRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<QuestionResultDto>?> ValidateAnswersAsync(Guid testID, List<UserQuestionAnswerDto> userQuestionAnswers)
    {
        var testWithRelatedData = await _dbContext.Tests
        .Where(t => t.TestID == testID)
        .Select(t => new RelatedTableTestDto
        {
            TestID = t.TestID,
            Questions = t.Questions.Select(q => new RelatedTableQuestionDto
            {
                QuestionID = q.QuestionID,
                CorrectAnswer = q.CorrectAnswer
            }).ToList()
        })
        .AsSplitQuery()
        .FirstOrDefaultAsync();

        if (testWithRelatedData == null) return null;

        var testQuestions = testWithRelatedData.Questions;

        var result = testQuestions
            .Select(question =>
            {
                var userAnswer = userQuestionAnswers.Find(uq => uq.QuestionID == question.QuestionID);

                if (userAnswer == null) return new QuestionResultDto { QuestionID = question.QuestionID, IsCorrect = false };
                else
                {
                    bool isCorrect = question.CorrectAnswer != null && question.CorrectAnswer.SequenceEqual(userAnswer.Answers);
                    return new QuestionResultDto { QuestionID = question.QuestionID, IsCorrect = isCorrect };
                }
            })
            .ToList();

        return result;
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Dtos.QuestionDto;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionRepository _questionRepo;
    private readonly IMapper _mapper;

    public QuestionController(IQuestionRepository questionRepo, IMapper mapper)
    {
        _questionRepo = questionRepo;
        _mapper = mapper;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateQuestion([FromBody] Question question)
    {
        var createdQuestion = await _questionRepo.CreateQuestionAsync(question);

        var createQuestionDto = _mapper.Map<QuestionDto>(createdQuestion);

        return CreatedAtAction(nameof(CreateQuestion), createQuestionDto);
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAllQuestions()
    {
        var allQuestions = await _questionRepo.GetAllQuestionsAsync();

        var allQuestionsDto = allQuestions.Select(q => _mapper.Map<QuestionDto>(q)).ToList();

        return Ok(allQuestionsDto);
    }

    [HttpGet("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetQuestionById([FromRoute] Guid id)
    {
        var expectedQuestion = await _questionRepo.GetQuestionByIdAsync(id);

        if (expectedQuestion == null) return NotFound();

        var expectedQuestionDto = _mapper.Map<QuestionDto>(expectedQuestion);

        return Ok(expectedQuestionDto);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateQuestion([FromRoute] Guid id, [FromBody] Question question)
    {
        var updatedQuestion = await _questionRepo.UpdateQuestionAsync(id, question);

        if (updatedQuestion == null) return NotFound();

        var updatedQuestionDto = _mapper.Map<QuestionDto>(updatedQuestion);

        return Ok(updatedQuestionDto);
    }

    [HttpDelete("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> DeleteQuestion([FromRoute] Guid id)
    {
        var deletedQuestion = await _questionRepo.DeleteQuestionAsync(id); 
        
        if (deletedQuestion == null) return NotFound();

        return NoContent();
    }
}

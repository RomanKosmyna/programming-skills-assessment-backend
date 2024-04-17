﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Dtos.AnswerOption;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
public class AnswerOptionController : ControllerBase
{
    private readonly IAnswerOptionRepository _answerOptionRepo;
    private readonly IMapper _mapper;

    public AnswerOptionController(IAnswerOptionRepository answerOptionRepo, IMapper mapper)
    {
        _answerOptionRepo = answerOptionRepo;
        _mapper = mapper;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAnswerOption([FromBody] AnswerOption answerOption)
    {
        var createdAnswerOption = await _answerOptionRepo.CreateAnswerOptionAsync(answerOption);

        var createdAnswerOptionDto = _mapper.Map<AnswerOptionDto>(createdAnswerOption);

        return CreatedAtAction(nameof(CreateAnswerOption), createdAnswerOptionDto);
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAllAnswerOptions()
    {
        var allAnswerOptions = await _answerOptionRepo.GetAllAnswerOptionsAsync();

        var allAnswerOptionsDto = allAnswerOptions.Select(a => _mapper.Map<AnswerOptionDto>(a)).ToList();

        return Ok(allAnswerOptionsDto);
    }

    [HttpGet("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAnswerOptionById([FromRoute] Guid id)
    {
        var expectedAnswerOption = await _answerOptionRepo.GetAnswerOptionByIdAsync(id);

        if (expectedAnswerOption == null) return NotFound();

        var expectedAnswerOptionDto = _mapper.Map<AnswerOptionDto>(expectedAnswerOption);

        return Ok(expectedAnswerOptionDto);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateAnswerOption([FromRoute] Guid id, [FromBody] AnswerOption answerOption)
    {
        var updatedAnswerOption = await _answerOptionRepo.UpdateAnswerOptionAsync(id, answerOption);

        if (updatedAnswerOption == null) return NotFound();

        var updatedAnswerOptionDto = _mapper.Map<AnswerOptionDto>(updatedAnswerOption);

        return Ok(updatedAnswerOptionDto);
    }

    [HttpDelete("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> DeleteAnswerOption([FromRoute] Guid id)
    {
        var deletedAnswerOption = await _answerOptionRepo.DeleteAnswerOptionAsync(id);

        if (deletedAnswerOption == null) return NotFound();

        return NoContent();
    }
}

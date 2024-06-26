﻿using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Dtos.TestResult;
using programming_skills_assessment_backend.Interfaces;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/testresult")]
[ApiController]
public class TestResultController : ControllerBase
{
    private readonly ITestResultRepository _resultRepo;

    public TestResultController(ITestResultRepository resultRepo)
    {
        _resultRepo = resultRepo;
    }

    [HttpPost("formtestresult/{testID:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> FormTestResult([FromRoute] Guid testID, [FromBody] List<UserQuestionAnswerDto> userQuestionAnswers)
    {
        var validateAnswers = await _resultRepo.ValidateAnswersAsync(testID, userQuestionAnswers);

        return Ok(validateAnswers);
    }
}

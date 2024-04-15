using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ITestRepository _testRepo;

    public TestController(ITestRepository testRepo)
    {
        _testRepo = testRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allTests = await _testRepo.GetAllAsync();

        if (allTests == null) return NotFound();

        return Ok(allTests);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var test = await _testRepo.GetByIdWithQuestionsAsync(id);

        if (test == null) return NotFound();

        return Ok(test);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Test test)
    {
        var createTest = await _testRepo.CreateAsync(test);

        return CreatedAtAction(nameof(Create), createTest);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] JsonPatchDocument<Test> test)
    {
        var updatedTest = await _testRepo.UpdateAsync(id, test);

        if (updatedTest == null) return NotFound();

        return Ok(updatedTest);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var test = await _testRepo.DeleteAsync(id);

        if (test == null) return NotFound();

        return NoContent();
    }
}

using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;
using programming_skills_assessment_backend.Repository;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly TestRepository _testRepo;

    public TestController(TestRepository testRepo)
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

    [HttpPatch]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Test test)
    {
        var updatedTest = await _testRepo.UpdateAsync(id, test);

        if (updatedTest == null) return NotFound();

        return Ok(updatedTest);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var test = await _testRepo.DeleteAsync(id);

        if (test == null) return NotFound();

        return NoContent();
    }
}

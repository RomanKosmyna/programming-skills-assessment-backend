using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestTypeController : ControllerBase
{
    private readonly ITestTypeRepository _testTypeRepo;

    public TestTypeController(ITestTypeRepository testTypeRepo)
    {
        _testTypeRepo = testTypeRepo;
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    //[ServiceFilter(typeof(ValidateEntitiesExistAttribute<TestTypeDto>))]
    public async Task<IActionResult> GetAll()
    {
        var allTestTypes = await _testTypeRepo.GetAllAsync();

        if (allTestTypes == null) return NotFound();

        return Ok(allTestTypes);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var testType = await _testTypeRepo.GetByIdAsync(id);

        if (testType == null) return NotFound();

        return Ok(testType);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Create([FromBody] TestType testType)
    {
        var createTestType = await _testTypeRepo.CreateAsync(testType);

        return CreatedAtAction(nameof(Create), createTestType);
    }

    [HttpDelete("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var testType = await _testTypeRepo.DeleteAsync(id);

        if (testType == null) return NotFound();

        return NoContent();
    }
}

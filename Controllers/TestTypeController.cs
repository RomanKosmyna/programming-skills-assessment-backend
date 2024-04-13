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
    //[ServiceFilter(typeof(ValidateEntitiesExistAttribute<TestType>))]
    public async Task<IActionResult> GetAll()
    {
        var testTypes = await _testTypeRepo.GetAllAsync();

        if (testTypes == null) return NotFound();

        return Ok(testTypes);
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.Dtos.TestType;
using programming_skills_assessment_backend.Interfaces;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestTypeController : ControllerBase
{
    private readonly ITestTypeRepository _testTypeRepo;
    private readonly IMapper _mapper;

    public TestTypeController(ITestTypeRepository testTypeRepo, IMapper mapper)
    {
        _testTypeRepo = testTypeRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var testTypes = await _testTypeRepo.GetAllAsync();

        if (testTypes == null) return NotFound();

        return Ok(testTypes);
    }
}

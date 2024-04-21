using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Dtos.TestDto;
using programming_skills_assessment_backend.Dtos.TestTypeDto;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

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

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateTestType([FromBody] TestType testType)
    {
        var createdTestType = await _testTypeRepo.CreateTestTypeAsync(testType);

        var createdTestTypeDto = _mapper.Map<TestTypeDto>(createdTestType);

        return CreatedAtAction(nameof(CreateTestType), createdTestTypeDto);
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAllTestTypes()
    {
        var allTestTypes = await _testTypeRepo.GetAllTestTypesAsync();

        var allTestTypesDto = allTestTypes.Select(t => _mapper.Map<TestTypeDto>(t)).ToList();

        return Ok(allTestTypesDto);
    }

    [HttpGet("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetTestTypeById([FromRoute] Guid id)
    {
        var expectedTestType = await _testTypeRepo.GetTestTypeByIdAsync(id);

        if (expectedTestType == null) return NotFound();

        var expectedTestTypeDto = _mapper.Map<TestTypeDto>(expectedTestType);

        return Ok(expectedTestTypeDto);
    }

    [HttpGet("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetTestsByTestTypeId([FromRoute] Guid id)
    {
        var tests = await _testTypeRepo.GetTestsByTestTypeIdAsync(id);

        if (tests == null) return NotFound();

        var testsDto = tests.Select(t => _mapper.Map<TestDto>(t)).ToList();

        return Ok(testsDto);
    }

    [HttpDelete("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> DeleteTestType([FromRoute] Guid id)
    {
        var deletedTestType = await _testTypeRepo.DeleteTestTypeAsync(id);

        if (deletedTestType == null) return NotFound();

        return NoContent();
    }
}

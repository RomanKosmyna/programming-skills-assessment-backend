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
public class TestCategoryController : ControllerBase
{
    private readonly ITestCategoryRepository _testCategoryRepo;
    private readonly IMapper _mapper;

    public TestCategoryController(ITestCategoryRepository testCategoryRepo, IMapper mapper)
    {
        _testCategoryRepo = testCategoryRepo;
        _mapper = mapper;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateTestCategory([FromBody] TestCategory testCategory)
    {
        var createdTestCategory = await _testCategoryRepo.CreateTestCategoryAsync(testCategory);

        var createdTestCategoryDto = _mapper.Map<TestCategoryDto>(createdTestCategory);

        return CreatedAtAction(nameof(CreateTestCategory), createdTestCategoryDto);
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAllTestCategories()
    {
        var allTestTypes = await _testCategoryRepo.GetAllTestCategoriesAsync();

        var allTestTypesDto = allTestTypes.Select(t => _mapper.Map<TestCategoryDto>(t)).ToList();

        return Ok(allTestTypesDto);
    }

    [HttpGet("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetTestCategoryById([FromRoute] Guid id)
    {
        var expectedTestType = await _testCategoryRepo.GetTestCategoryByIdAsync(id);

        if (expectedTestType == null) return NotFound();

        var expectedTestTypeDto = _mapper.Map<TestCategoryDto>(expectedTestType);

        return Ok(expectedTestTypeDto);
    }

    [HttpDelete("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> DeleteTestCategory([FromRoute] Guid id)
    {
        var deletedTestCategory = await _testCategoryRepo.DeleteTestCategoryAsync(id);

        if (deletedTestCategory == null) return NotFound();

        return NoContent();
    }
}

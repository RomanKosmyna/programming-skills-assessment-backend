using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Dtos.TestDto;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ITestRepository _testRepo;
    private readonly IMapper _mapper;

    public TestController(ITestRepository testRepo, IMapper mapper)
    {
        _testRepo = testRepo;
        _mapper = mapper;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateTest([FromBody] Test test)
    {
        var createdTest = await _testRepo.CreateTestAsync(test);

        var createdTestDto = _mapper.Map<TestDto>(createdTest);

        return CreatedAtAction(nameof(CreateTest), createdTestDto);
    }

    [HttpGet]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAllTests()
    {
        var allTests = await _testRepo.GetAllTestsAsync();

        var allTestsDto = allTests.Select(t => _mapper.Map<TestDto>(t)).ToList();

        return Ok(allTestsDto);
    }

    [HttpGet("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetTestById([FromRoute] Guid id)
    {
        var expectedTest = await _testRepo.GetTestByIdAsync(id);

        if (expectedTest == null) return NotFound();

        var expectedTestDto = _mapper.Map<TestDto>(expectedTest);

        return Ok(expectedTestDto);
    }

    [HttpGet("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetTestByIdWithQuestions([FromRoute] Guid id)
    {
        var expectedTest = await _testRepo.GetTestByIdWithQuestionsAsync(id);

        if (expectedTest == null) return NotFound();

        var expectedTestDto = _mapper.Map<TestDto>(expectedTest);

        return Ok(expectedTestDto);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateTest([FromRoute] Guid id, [FromBody] Test test)
    {
        var updatedTest = await _testRepo.UpdateTestAsync(id, test);

        if (updatedTest == null) return NotFound();

        var updatedTestDto = _mapper.Map<TestDto>(updatedTest);

        return Ok(updatedTestDto);
    }

    [HttpDelete("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> DeleteTest([FromRoute] Guid id)
    {
        var deletedTest = await _testRepo.DeleteTestAsync(id);

        if (deletedTest == null) return NotFound();

        return NoContent();
    }
}

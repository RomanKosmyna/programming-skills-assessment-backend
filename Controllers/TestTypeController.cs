using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Dtos.TestType;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/testtype")]
[ApiController]
public class TestTypeController : ControllerBase
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IMapper _mapper;

    public TestTypeController(ApplicationDBContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTestTypeById([FromRoute] Guid id)
    {
        var testType = await _dbContext.TestTypes.FindAsync(id);

        if (testType == null) return NotFound();

        var testTypeDto = _mapper.Map<TestTypeDto>(testType);

        return Ok(testTypeDto);
    }
}

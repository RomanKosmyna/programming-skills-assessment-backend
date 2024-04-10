using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.Data;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ApplicationDBContext _dbContext;

    public TestController(ApplicationDBContext context)
    {
        _dbContext = context;
    }
}

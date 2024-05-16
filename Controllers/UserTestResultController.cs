using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Dtos.UserTestResult;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Controllers;

[Route("api/usertestresult")]
[ApiController]
[Authorize]
public class UserTestResultController : ControllerBase
{
    private readonly IUserTestResultRepository _userTestResultRepo;
    private readonly IMapper _mapper;

    public UserTestResultController(IUserTestResultRepository userTestResultRepo, IMapper mapper)
    {
        _userTestResultRepo = userTestResultRepo;
        _mapper = mapper;
    }

    [HttpPost("testresult")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> SaveUserTestResult([FromBody] UserTestResult userTestResult)
    {
        var createdTestResult = await _userTestResultRepo.SaveUserTestResultAsync(userTestResult);
        
        var createdTestResultDto = _mapper.Map<SaveUserTestResultDto>(createdTestResult);

        return CreatedAtAction(nameof(SaveUserTestResult), createdTestResultDto);
    }

    [HttpGet("testresults/{username}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAllUserTestResults([FromRoute] string username)
    {
        var allUserTestResult = await _userTestResultRepo.GetAllUserTestResultsAsync(username);

        var allUserTestResultDto = allUserTestResult.Select(utr => _mapper.Map<UserTestResultDto>(utr)).ToList();

        return Ok(allUserTestResultDto);
    }

    [HttpGet("testresult/{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetUserTestResultById([FromRoute] Guid id)
    {
        var userTestResult = await _userTestResultRepo.GetUserTestResultByIdAsync(id);

        if (userTestResult == null) return NotFound(new { message = "Such Test Result could not be found" });

        var userTestResultDto = _mapper.Map<SpecificTestResultDto>(userTestResult);

        return Ok(userTestResultDto);
    }

    [HttpDelete("testresult/{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> DeleteUserTestResult([FromRoute] Guid id)
    {
        var deletedTestResult = await _userTestResultRepo.DeleteUserTestResultAsync(id);

        if (deletedTestResult == null) return NotFound(new { message = "Such test result could not be found" });

        return NoContent();
    }
}

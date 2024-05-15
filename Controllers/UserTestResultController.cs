using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

    [HttpPost("savetestresult")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> SaveUserTestResult([FromBody] UserTestResult userTestResult)
    {
        var createdTestResult = await _userTestResultRepo.SaveUserTestResult(userTestResult);
        
        var createdTestResultDto = _mapper.Map<SaveUserTestResultDto>(createdTestResult);

        return CreatedAtAction(nameof(SaveUserTestResult), createdTestResultDto);
    }

    [HttpGet("getallusertestresults/{username}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetAllUserTestResults([FromRoute] string username)
    {
        var allUserTestResult = await _userTestResultRepo.GetAllUserTestResults(username);

        var allUserTestResultDto = allUserTestResult.Select(utr => _mapper.Map<UserTestResultDto>(utr)).ToList();

        return Ok(allUserTestResultDto);
    }

    [HttpGet("getusertestresultbyid/{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> GetUserTestResultById([FromRoute] Guid id)
    {
        var userTestResult = await _userTestResultRepo.GetUserTestResultById(id);

        if (userTestResult == null) return NotFound(new { message = "Such Test Result could not be found" });

        var userTestResultDto = _mapper.Map<SpecificTestResultDto>(userTestResult);

        return Ok(userTestResultDto);
    }

    [HttpDelete("deleteusertestresult/{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> DeleteUserTestResult([FromRoute] Guid id)
    {
        var deletedTestResult = await _userTestResultRepo.DeleteUserTestResult(id);

        if (deletedTestResult == null) return NotFound(new { message = "Such test result could not be found" });

        return NoContent();
    }
}

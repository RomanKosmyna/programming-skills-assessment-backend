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

        return Ok(createdTestResultDto);
    }
}

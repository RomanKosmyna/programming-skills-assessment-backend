using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Dtos.Account;
using programming_skills_assessment_backend.Dtos.User;
using programming_skills_assessment_backend.Models;
using programming_skills_assessment_backend.Service;

namespace programming_skills_assessment_backend.Controllers;

[Route("/api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> LoginUser([FromBody] UserLoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

        if (user == null) return Unauthorized("Invalid username");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized("Username or password are incorrect.");

        return Ok(new NewUserDto
        {
            UserName = user.UserName,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        });
    }

    [HttpPost("register")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
    {
        try
        {
            var appUser = new AppUser
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
            };

            var createdUser = await _userManager.CreateAsync(appUser, userRegisterDto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                if (roleResult.Succeeded)
                {
                    return Ok(new NewUserDto
                    {
                        UserName = appUser.UserName,
                        Email = appUser.Email,
                        Token = _tokenService.CreateToken(appUser)
                    });
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.Account;

public class UserLoginDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}

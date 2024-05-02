using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programming_skills_assessment_backend.Models;

[Table("Users")]
public class User
{
    public Guid UserID { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [MinLength(6), MaxLength(12)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,12}$", 
     ErrorMessage = "Password must have at least one alphabetic character, one digit, and be between 6 to 12 characters long.")]
    public string Password { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace programming_skills_assessment_backend.Dtos.User;

public class UserRegisterDto
{
    public Guid UserID { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    //[DataType(DataType.Password)]
    //[MinLength(6), MaxLength(12)]
    //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,12}$",
    // ErrorMessage = "Password must have at least one alphabetic character, one digit, and be between 6 to 12 characters long")]
    public string Password { get; set; }
    //[Required]
    //[DataType(DataType.Password)]
    //[Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    //public string ConfirmPassword { get; set; }
}

using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Service;

public interface ITokenService
{
    string CreateToken(AppUser user);
}

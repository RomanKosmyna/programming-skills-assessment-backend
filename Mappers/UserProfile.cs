using AutoMapper;
using programming_skills_assessment_backend.Dtos.User;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRegisterDto, AppUser>();
    }
}

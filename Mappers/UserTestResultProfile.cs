using AutoMapper;
using programming_skills_assessment_backend.Dtos.UserTestResult;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class UserTestResultProfile : Profile
{
    public UserTestResultProfile()
    {
        CreateMap<UserTestResult, SaveUserTestResultDto>();
        CreateMap<UserTestResult, UserTestResultDto>();
    }
}

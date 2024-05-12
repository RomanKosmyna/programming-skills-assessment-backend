using AutoMapper;
using programming_skills_assessment_backend.Dtos.QuestionResult;
using programming_skills_assessment_backend.Dtos.UserTestResult;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class UserTestResultProfile : Profile
{
    public UserTestResultProfile()
    {
        CreateMap<UserTestResult, SaveUserTestResultDto>();
        CreateMap<UserTestResult, UserTestResultDto>();
        CreateMap<UserTestResult, SpecificTestResultDto>()
            .ForMember(dest => dest.QuestionData, opt => opt.MapFrom(src =>
                src.QuestionData.Select(qr => new QuestionResultDto
                {
                    QuestionResultID = qr.QuestionResultID,
                    IsCorrect = qr.IsCorrect,
                    QuestionID = qr.QuestionID
                })
            ));
    }
}

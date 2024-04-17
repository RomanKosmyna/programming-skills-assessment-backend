using AutoMapper;
using programming_skills_assessment_backend.Dtos.AnswerOption;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class AnswerOptionProfile : Profile
{
    public AnswerOptionProfile()
    {
        CreateMap<AnswerOption, AnswerOptionDto>();
    }
}

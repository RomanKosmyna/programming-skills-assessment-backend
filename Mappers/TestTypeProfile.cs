using AutoMapper;
using programming_skills_assessment_backend.Dtos.TestType;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class TestTypeProfile : Profile
{
    public TestTypeProfile()
    {
        CreateMap<TestType, TestTypeDto>().ReverseMap();
    }
}

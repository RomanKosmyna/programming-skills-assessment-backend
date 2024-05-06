using AutoMapper;
using programming_skills_assessment_backend.Dtos.TestTypeDto;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class TestCategoryProfile : Profile
{
    public TestCategoryProfile()
    {
        CreateMap<TestCategory, TestCategoryDto>()
            .ForMember(tc => tc.Tests, tc => tc.Ignore());
    }
}

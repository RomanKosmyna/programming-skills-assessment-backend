﻿using AutoMapper;
using programming_skills_assessment_backend.Dtos.Test;
using programming_skills_assessment_backend.Dtos.TestDto;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<Test, TestDto>().ReverseMap();
        CreateMap<Test, TestByTestCategoryDto>().ReverseMap();
        CreateMap<Test, ActiveTestDto>().ReverseMap();
    }
}

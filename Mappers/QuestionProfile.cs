﻿using AutoMapper;
using programming_skills_assessment_backend.Dtos.QuestionDtos;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Mappers;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Question, QuestionDto>();
    }
}

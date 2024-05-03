﻿using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Interfaces;

public interface IUserRepository
{
    Task<AppUser> RegisterUser(AppUser user);
}

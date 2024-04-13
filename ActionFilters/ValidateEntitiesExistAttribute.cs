using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using programming_skills_assessment_backend.Data;

namespace programming_skills_assessment_backend.ActionFilters;

public class ValidateEntitiesExistAttribute<T> : IActionFilter where T: class
{
    private readonly ApplicationDBContext _dbContext;

    public ValidateEntitiesExistAttribute(ApplicationDBContext context)
    {
        _dbContext = context;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var entityStatus = _dbContext.Set<T>().Any();

        if (!entityStatus)
        {
            context.Result = new NotFoundResult();
        }
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}

using Microsoft.AspNetCore.Diagnostics;
using programming_skills_assessment_backend.Models;
using System.Net;

namespace programming_skills_assessment_backend.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;

                    string errorMessage = exception switch
                    {
                        FileNotFoundException fileNotFoundException => "Error: File not found.",
                        ArgumentException argumentException => "Error: Invalid argument.",
                        _ => "Internal Server Error."
                    };

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = errorMessage
                    }.ToString());
                }
            });
        });
    }
}

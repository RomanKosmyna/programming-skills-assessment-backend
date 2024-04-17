using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.ActionFilters;
using programming_skills_assessment_backend.Data;
using programming_skills_assessment_backend.Extensions;
using programming_skills_assessment_backend.Interfaces;
using programming_skills_assessment_backend.Models;
using programming_skills_assessment_backend.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configuring AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
// Connecting first Database (Tests)
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestsDatabaseConnection"));
});
// Initializing SQLite database
//ExceptionDatabaseHelper.InitializeDatabase();

//Configure Serilog logger with a SQLite database
Log.Logger = new LoggerConfiguration()
    //.ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    //.WriteTo.SQLite("ExceptionDB\\ExceptionHandler.db", tableName: "exceptions", batchSize: 1)
    .CreateLogger();
builder.Host.UseSerilog();

// Dependecy Injections
builder.Services.AddScoped<ITestTypeRepository, TestTypeRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAnswerOptionRepository, AnswerOptionRepository>();
// Action filters
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<ValidateEntitiesExistAttribute<TestType>>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global exception handler
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

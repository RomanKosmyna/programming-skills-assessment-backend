using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Data;

public class ApplicationDBContext : DbContext
{
    public DbSet<TestType> TestTypes { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}

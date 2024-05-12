using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using programming_skills_assessment_backend.Models;

namespace programming_skills_assessment_backend.Data;

public class ApplicationDBContext : IdentityDbContext<AppUser>
{
    public DbSet<TestCategory> TestCategories { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<AnswerOption> AnswerOptions { get; set; }
    public DbSet<UserTestResult> UserTestResults { get; set; }

    public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .Entity<TestCategory>()
            .HasMany(tc => tc.Tests)
            .WithOne(t => t.TestCategory)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<UserTestResult>()
            .HasMany(utr => utr.QuestionData)
            .WithOne(qd => qd.UserTestResult)
            .OnDelete(DeleteBehavior.Cascade);

        List<IdentityRole> roles =
        [
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        ];

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
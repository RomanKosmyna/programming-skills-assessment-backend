namespace programming_skills_assessment_backend.Dtos.TestTypeDto;

public class TestCategoryDto
{
    public Guid TestCategoryID { get; set; }
    public string TestCategoryName { get; set; }
    public List<Models.Test> Tests { get; set; }
}
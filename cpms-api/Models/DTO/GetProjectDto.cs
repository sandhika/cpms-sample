namespace cpms.Api.Models.DTO;

public record GetProjectDto(int Id,string Code, string Name, string? Description, DateTime StartDate, DateTime EndDate, decimal Budget,ProjectStatusEnum ProjectStage,string ProjectCategory,int? user)
{
    public static Project ToProject(GetProjectDto project)
    {
        return new Project
        {
            Id = project.Id,
            Code = project.Code,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            Budget = project.Budget,
            ProjectCategory = project.ProjectCategory,
            ProjectStage = project.ProjectStage,
            UserId = project.user
        };
    }
}
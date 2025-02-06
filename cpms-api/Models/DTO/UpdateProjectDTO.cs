using System.ComponentModel.DataAnnotations;

namespace cpms.Api.Models.DTO;

public class UpdateProjectDTO
{
    public int Id { get; set; }

    public required string Code { get; set; }
    public required string Name { get; set; }

    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
   
    public DateTime EndDate { get; set; }
   
    public decimal Budget { get; set; }
    
     public ProjectStatusEnum? ProjectStage { get; set; }
    
     public string? ProjectCategory { get; set; }

 public int UserId { get; set; } 
    public static Project ToProject(UpdateProjectDTO updateProjectDto)
    {
        return new Project
        {
            Id= updateProjectDto.Id,
            Code = updateProjectDto.Code,
            Name = updateProjectDto.Name,
            Description = updateProjectDto.Description,
            StartDate = updateProjectDto.StartDate.ToUniversalTime(),
            EndDate = updateProjectDto.EndDate.ToUniversalTime(),
            Budget = updateProjectDto.Budget,
            ProjectStage = updateProjectDto.ProjectStage,
            ProjectCategory = updateProjectDto.ProjectCategory,
            UserId = updateProjectDto.UserId
            
        };
    }
}
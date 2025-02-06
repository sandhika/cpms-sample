using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using cpms.Api.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace cpms.Api.Models;

[Table("Project")]
[Index(nameof(Project.Code), IsUnique = true)]
public class Project
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(10)")]
    [Required]
    public required string Code { get; set; }
    

    [Column(TypeName = "varchar(30)")]
    [Required]
    public required string Name { get; set; }
    
    public ProjectStatusEnum? ProjectStage { get; set; }
    
    [AllowNull]
    public string? Description { get; set; }

     public string? ProjectCategory { get; set; }
   
    [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
   
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Range(0, double.MaxValue)]
   
        public decimal Budget { get; set; }

        public int? UserId { get; set; } 

    public static GetProjectDto ToGetProjectDto(Project project)
    {
        return new GetProjectDto(project.Id, project.Code,project.Name, project.Description, project.StartDate,project.EndDate, project.Budget,project.ProjectStage.Value,project.ProjectCategory,project.UserId);
    }
}

public enum ProjectStatusEnum
{
    Concept = 0,
    DesignAndDocumentation = 1,
    PreContruction = 2,
    Contruction = 3
}

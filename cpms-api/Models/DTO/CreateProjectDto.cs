using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Npgsql.Replication;

namespace cpms.Api.Models.DTO;

public class CreateProjectDTO
{

    public required string Code { get; set; } 
   
    public required string Name { get; set; }

     public string? Description { get; set; }

     [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
     public DateTime StartDate { get; set; }
   
    public DateTime EndDate { get; set; }
   
    public decimal Budget { get; set; }

    public ProjectStatusEnum? ProjectStage { get; set; }
    public string? ProjectCategory { get; set; }

    public int UserId { get; set; } 
    private static string RandomNumber()
    {

        Random generator = new Random();
        String r = generator.Next(0, 1000000).ToString("D6");

        return r;
    }

    public static Project ToProject(CreateProjectDTO project)
    {
        return new Project
        {
            Code = RandomNumber(),
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate.ToUniversalTime(),
            EndDate = project.EndDate.ToUniversalTime(),
            Budget = project.Budget,
            ProjectCategory = project.ProjectCategory,
            ProjectStage = project.ProjectStage,
            UserId = project.UserId
        };
    }


}
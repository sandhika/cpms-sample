using cpms.Api.Models;
using cpms.Api.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace cpms.Api.Services;

public interface IProjectService
{
    Task<GetProjectDto> AddProjectAsync(CreateProjectDTO projectToCreate);
    Task UpdateProjectAsync(UpdateProjectDTO projectToUpdate);
    Task DeleteProjectAsync(Project project);
    Task<GetProjectDto?> FindProjectByIdAsync(int id);
    Task<IEnumerable<GetProjectDto>> GetProjectAsync();
}
public sealed class ProjectService : IProjectService
{
    private readonly ApplicationDbContext _context;

    public ProjectService(ApplicationDbContext context)
    {
        _context = context;
    }

    private string RandomNumber()
    {

        Random generator = new Random();
        String r = generator.Next(0, 1000000).ToString("D6");

        return r;
    }
    public async Task<GetProjectDto> AddProjectAsync(CreateProjectDTO projectToCreate)
    {
        
        Project project = CreateProjectDTO.ToProject(projectToCreate);
        // project.Id = RandomNumber();
        _context.Project.Add(project);
        await _context.SaveChangesAsync();
        return Project.ToGetProjectDto(project);
    }

    public async Task DeleteProjectAsync(Project project)
    {
        _context.Project.Remove(project);
        await _context.SaveChangesAsync();
    }

    public async Task<GetProjectDto?> FindProjectByIdAsync(int id)
    {
        Project? project = await _context.Project.Where(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        if (project == null)
        {
            return null;
        }
        return Project.ToGetProjectDto(project);
    }

    public async Task<IEnumerable<GetProjectDto>> GetProjectAsync()
    {
        IEnumerable<Project> people = await _context.Project.AsNoTracking().ToListAsync();
        return people.Select(Project.ToGetProjectDto);
    }

    public async Task UpdateProjectAsync(UpdateProjectDTO projectToUpdate)
    {
        Project project = UpdateProjectDTO.ToProject(projectToUpdate);
        _context.Project.Update(project);
        await _context.SaveChangesAsync();
    }
}
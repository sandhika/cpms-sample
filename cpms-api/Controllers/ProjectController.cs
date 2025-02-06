using cpms.Api.Models.DTO;
using cpms.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace cpms.Api.Controllers;

[Authorize]
[Route("[controller]/[action]")]
[ApiController]
public class ProjectController : ControllerBase 
{
    private readonly IProjectService _projectService;
    private readonly IAuthService _autService;
    private readonly ILogger<ProjectController> _logger;

    public ProjectController(IProjectService projectService, ILogger<ProjectController> logger,IAuthService autService)
    {
        _projectService = projectService;
        _logger = logger;
        _autService = autService;
    }
    [HttpPost]
    public async Task<IActionResult> Add(CreateProjectDTO projectToCreate)
    {
        try
        {
            var dtUsr = await _autService.GetByName(User.Identity.Name);
            
            projectToCreate.UserId = dtUsr.Id;
       
            var project = await _projectService.AddProjectAsync(projectToCreate);
            return Ok(project);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProjectDTO projectToUpdate)
    {
        if (projectToUpdate.Id != id)
        {
            return BadRequest($"id in parameter and id in body is different. id in parameter: {id}, id in body: {projectToUpdate.Id}");
        }
        try
        {
            GetProjectDto? project = await _projectService.FindProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            await _projectService.UpdateProjectAsync(projectToUpdate);
            return Ok(projectToUpdate);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ById(int id)
    {
        try
        {
            GetProjectDto? project = await _projectService.FindProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        try
        {
            IEnumerable<GetProjectDto> projects = await _projectService.GetProjectAsync();
            return Ok(projects);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            GetProjectDto? project = await _projectService.FindProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            await _projectService.DeleteProjectAsync(GetProjectDto.ToProject(project));
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
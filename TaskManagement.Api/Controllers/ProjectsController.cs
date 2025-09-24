using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TaskManagement.Api.Filters;
using TaskManagement.Business.DTOs;
using TaskManagement.Business.Interfaces;
using TaskManagement.Business.ResponseModels;

namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiResponseWrapperFilter))]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsServices _projectsServices;

        public ProjectsController(IProjectsServices projectsServices)
        {
            _projectsServices = projectsServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetProjects()
        {
            var projects = await _projectsServices.GetAllProjectsAsync();
            //return Ok(ApiResponseFactory.Success(projects));
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProject(int id)
        {
            var project = await _projectsServices.GetProjectByIdAsync(id);
            if (project == null)
                // return NotFound(ApiResponseFactory.NotFound<object>());
                return NotFound();
            //return Ok(ApiResponseFactory.Success(project));
            return Ok(project);
        }
    }
}
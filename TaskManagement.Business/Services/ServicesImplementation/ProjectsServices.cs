using AutoMapper;
using TaskManagement.Business.DTOs;
using TaskManagement.Business.Interfaces;
using TaskManagement.Data.Repositories.Interfaces;
namespace TaskManagement.Business.Services
{
    public class ProjectsServices : IProjectsServices
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IMapper _mapper;

        public ProjectsServices(IProjectsRepository projectsRepository, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _projectsRepository.GetAllAsync();
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(int id)
        {
            var project = await _projectsRepository.GetByIdAsync(id);
            return project == null ? null : _mapper.Map<ProjectDto>(project);
        }
    }
}

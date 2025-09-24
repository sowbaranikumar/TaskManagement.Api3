using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TaskManagement.Business.DTOs;

namespace TaskManagement.Business.Interfaces
{
    public interface IProjectsServices
    {
        Task<List<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto?> GetProjectByIdAsync(int id);
    }
}


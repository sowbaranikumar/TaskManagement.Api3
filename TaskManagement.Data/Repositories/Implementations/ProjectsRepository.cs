using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Db;
using TaskManagement.Data.Repositories.Interfaces;
using TaskManagement.Entity.Entities;
namespace TaskManagement.Data.Repositories.Implementations
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly AppDbContext _context;

        public ProjectsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.Include(p => p.Tasks).ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.Tasks)
                                          .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Entity.Entities;

//namespace TaskManagement.Data.Repositories.Interfaces
//{
//    public interface IProjectsRepository
//    {
//        Task<List<Project>> GetAllProjectsAsync();
//        Task<Project?> GetByIdAsync(int id);
//    }
//}


namespace TaskManagement.Data.Repositories.Interfaces
{
    public interface IProjectsRepository : IGenericRepository<Project>
    {
        
    }
}




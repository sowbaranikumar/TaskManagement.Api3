using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

//namespace TaskManagement.Data.Repositories.Interfaces
//{
//    public interface ITasksRepository
//    {
//        Task<List<TaskItem>> GetAllAsync();
//        Task<TaskItem?> GetByIdAsync(int id);
//        Task<List<TaskItem>> GetTasksByUserIdAsync(int userId);
//        Task<List<TaskItem>> GetTasksDueThisWeekAsync();
//        Task<List<TaskItem>> GetOverdueOrIncompleteTasksAsync();
//        Task<Dictionary<int, int>> GetCompletedTaskCountPerUserAsync();
//        Task<TaskItem> CreateTaskAsync(TaskItem task);
//        Task<bool> UpdateTaskAsync(TaskItem task);
//        Task<bool> DeleteTaskAsync(int id);
//    }
//}


namespace TaskManagement.Data.Repositories.Interfaces
{
    public interface ITasksRepository : IGenericRepository<TaskItem>
    {
        Task<List<TaskItem>> GetTasksByUserIdAsync(int userId);
        Task<List<TaskItem>> GetTasksDueThisWeekAsync();
        Task<List<TaskItem>> GetOverdueOrIncompleteTasksAsync();
        Task<Dictionary<int, int>> GetCompletedTaskCountPerUserAsync();
      //  Task<List<TaskItem>> GetTaskByUserIdSPAsync(int userId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Business.DTOs;
namespace TaskManagement.Business.Interfaces
{
    public interface ITasksServices
    {
        Task<List<TaskItemDto>> GetAllTasksAsync();
        Task<TaskItemDto?> GetTaskByIdAsync(int id);
        Task<List<TaskItemDto>> GetTasksByUserIdAsync(int userId);
        Task<List<TaskItemDto>> GetTasksDueThisWeekAsync();
        Task<List<TaskItemDto>> GetOverdueOrIncompleteTasksAsync();
        Task<Dictionary<int,int>> GetCompletedTaskCountPerUserAsync();
        Task<TaskItemDto> CreateTaskAsync(TaskItemDto dto);
        Task<bool> UpdateTaskAsync(TaskItemDto dto);
        Task<bool> DeleteTaskAsync(int id);
    }
   
}

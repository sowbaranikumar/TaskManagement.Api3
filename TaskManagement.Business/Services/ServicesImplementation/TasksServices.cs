using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Business.DTOs;
using TaskManagement.Business.Interfaces;
using TaskManagement.Data.Repositories.Interfaces;
using TaskManagement.Entity.Entities;
namespace TaskManagement.Business.Services
{
    public class TasksServices : ITasksServices
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IMapper _mapper;

        public TasksServices(ITasksRepository tasksRepository, IMapper mapper)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskItemDto>> GetAllTasksAsync()
        {
            var tasks = await _tasksRepository.GetAllAsync();
            return _mapper.Map<List<TaskItemDto>>(tasks);
        }

        public async Task<TaskItemDto?> GetTaskByIdAsync(int id)
        {
            var task = await _tasksRepository.GetByIdAsync(id);
            return task == null ? null : _mapper.Map<TaskItemDto>(task);
        }

        public async Task<TaskItemDto> CreateTaskAsync(TaskItemDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            var createdTask = await _tasksRepository.AddAsync(task);
            return _mapper.Map<TaskItemDto>(createdTask);
        }

        public async Task<bool> UpdateTaskAsync(TaskItemDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            var updatedTask = await _tasksRepository.UpdateAsync(task);
            return updatedTask != null;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
           
            await _tasksRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<TaskItemDto>> GetTasksByUserIdAsync(int userId)
        {
            var tasks = await _tasksRepository.GetTasksByUserIdAsync(userId);
            return _mapper.Map<List<TaskItemDto>>(tasks);
        }

        public async Task<List<TaskItemDto>> GetTasksDueThisWeekAsync()
        {
            var tasks = await _tasksRepository.GetTasksDueThisWeekAsync();
            return _mapper.Map<List<TaskItemDto>>(tasks);
        }

        public async Task<List<TaskItemDto>> GetOverdueOrIncompleteTasksAsync()
        {
            var tasks = await _tasksRepository.GetOverdueOrIncompleteTasksAsync();
            return _mapper.Map<List<TaskItemDto>>(tasks);
        }

        public async Task<Dictionary<int, int>> GetCompletedTaskCountPerUserAsync()
        {
            return await _tasksRepository.GetCompletedTaskCountPerUserAsync();
        }
    }
}

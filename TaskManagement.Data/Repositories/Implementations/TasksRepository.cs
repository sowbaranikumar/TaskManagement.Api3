using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data.Db;
using TaskManagement.Data.Repositories.Interfaces;
using TaskManagement.Entity.Entities;


//namespace TaskManagement.Data.Repositories.Implementations
//{
//    public class TasksRepository : ITasksRepository
//    {
//        private readonly AppDbContext _context;

//        public TasksRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<TaskItem>> GetAllAsync()
//        {
//            return await _context.Tasks.ToListAsync();
//        }

//        public async Task<TaskItem?> GetByIdAsync(int id)
//        {
//            return await _context.Tasks.FindAsync(id);
//        }

//        public async Task<List<TaskItem>> GetTasksByUserIdAsync(int userId)
//        {
//            return await _context.Tasks
//                .Where(t => t.UserId == userId)
//                .ToListAsync();
//        }

//        public async Task<List<TaskItem>> GetTasksDueThisWeekAsync()
//        {
//            var start = DateTime.Today;
//            var end = start.AddDays(7);

//            return await _context.Tasks
//                .Where(t => t.DueDate >= start && t.DueDate <= end)
//                .ToListAsync();
//        }

//        public async Task<List<TaskItem>> GetOverdueOrIncompleteTasksAsync()
//        {
//            var today = DateTime.Today;
//            return await _context.Tasks
//                .Where(t => !t.IsCompleted || t.DueDate < today)
//                .ToListAsync();
//        }

//        public async Task<Dictionary<int, int>> GetCompletedTaskCountPerUserAsync()
//        {
//            return await _context.Tasks
//                .Where(t => t.IsCompleted)
//                .GroupBy(t => t.UserId)
//                .ToDictionaryAsync(g => g.Key, g => g.Count());
//        }

//        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
//        {
//            await _context.Tasks.AddAsync(task);
//            await _context.SaveChangesAsync();
//            return task;
//        }

//        public async Task<bool> UpdateTaskAsync(TaskItem task)
//        {
//            var existingTask = await _context.Tasks.FindAsync(task.Id);
//            if (existingTask == null)
//                return false;

//            existingTask.Title = task.Title;
//            existingTask.Description = task.Description;
//            existingTask.DueDate = task.DueDate;
//            existingTask.Priority = task.Priority;
//            existingTask.IsCompleted = task.IsCompleted;
//            existingTask.UserId = task.UserId;
//            existingTask.ProjectId = task.ProjectId;
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> DeleteTaskAsync(int id)
//        {
//            var task = await _context.Tasks.FindAsync(id);
//            if (task == null)
//                return false;

//            _context.Tasks.Remove(task);
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}

namespace TaskManagement.Data.Repositories.Implementations
{
    public class TasksRepository:GenericRepository<TaskItem>,ITasksRepository
    {
        private readonly AppDbContext _context;

        public TasksRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

                //.Where(t => t.UserId == userId)
        public async Task<List<TaskItem>> GetTasksByUserIdAsync(int userId)
        {
            return await _context.Tasks
                 .FromSqlRaw("EXEC GetTasksByUserId @UserId ={0}",userId)
                 .ToListAsync();
        }

        public async Task<List<TaskItem>> GetTasksDueThisWeekAsync()
        {
            var start = DateTime.Today;
            var end = start.AddDays(7);

            return await _context.Tasks
                .Where(t => t.DueDate >= start && t.DueDate <= end)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetOverdueOrIncompleteTasksAsync()
        {
            var today = DateTime.Today;
            return await _context.Tasks
                .Where(t => !t.IsCompleted || t.DueDate < today)
                .ToListAsync();
        }

        public async Task<Dictionary<int, int>> GetCompletedTaskCountPerUserAsync()
        {
            return await _context.Tasks
                .Where(t => t.IsCompleted)
                .GroupBy(t => t.UserId)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }
    }
}
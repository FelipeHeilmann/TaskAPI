using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;
        public TaskRepository(TaskDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<TaskModel>> GetTasks()
        {
            return await _dbContext.Tasks
                .Include(task => task.User)
                .ToListAsync();
        }
        public async Task<TaskModel> GetTaskById(int taskId)
        {
            return await _dbContext.Tasks
                .Include(task => task.User)
                .FirstOrDefaultAsync(task => task.Id == taskId);
        }
        public async Task<TaskModel> CreateTask(TaskModel task)
        {
            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }
        public async Task<TaskModel> UpdateTask(TaskModel task, int taskId)
        {
            TaskModel taskAlreadyExists = await GetTaskById(taskId) ?? throw new Exception("Task not found");

            taskAlreadyExists.Name = task.Name;
            taskAlreadyExists.Description = task.Description;
            taskAlreadyExists.Status = task.Status;

            _dbContext.Update(taskAlreadyExists);
            await _dbContext.SaveChangesAsync();
            return taskAlreadyExists;
        }
        public async Task<bool> DeleteTask(int taskId)
        {
            TaskModel taskAlreadyExists = await GetTaskById(taskId) ?? throw new Exception("Task not found");

            _dbContext.Remove(taskAlreadyExists);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
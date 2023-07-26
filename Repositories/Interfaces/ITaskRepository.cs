using TaskApi.Models;

namespace TaskApi.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetTasks();
        Task<TaskModel> GetTaskById(int taskId);
        Task<TaskModel> CreateTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int taskId);
        Task<bool> DeleteTask(int taskId);
    }
}
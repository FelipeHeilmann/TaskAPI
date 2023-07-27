using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Repositories.Interfaces;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("tasks")]
        [Authorize]
        public async Task<ActionResult<List<TaskModel>>> GetTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("task/{id}")]
        [Authorize]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            TaskModel task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost("newTask")]
        [Authorize]
        public async Task<ActionResult<TaskModel>> CreateTask([FromBody] TaskModel task)
        {
            if (!Guid.TryParse(User.Claims.FirstOrDefault(x => x.Type.Equals("id", StringComparison.InvariantCultureIgnoreCase))?.Value, out var userIdGuid))
            {
                return BadRequest("Id do usuário inválido no token.");
            }

            task.UserId = userIdGuid;

            TaskModel newTask = await _taskRepository.CreateTask(task);
            return Ok(newTask);
        }

        [HttpPut("task/{id}")]
        [Authorize]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel task, int id)
        {
            task.Id = id;
            TaskModel changedTask = await _taskRepository.UpdateTask(task, id);
            return Ok(changedTask);
        }

        [HttpDelete("task/{id}")]
        [Authorize]
        public async Task<ActionResult<Boolean>> DeleteTask(int id)
        {
            Boolean deletedTask = await _taskRepository.DeleteTask(id);
            return Ok(deletedTask);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Filters;
using TaskManagement.Business.DTOs;
using TaskManagement.Business.Interfaces;
using TaskManagement.Business.ResponseModels;

namespace TaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [ServiceFilter(typeof(ApiResponseWrapperFilter))]
    public class TasksController : ControllerBase
    {
        private readonly ITasksServices _tasksServices;

        public TasksController(ITasksServices tasksServices)
        {
            _tasksServices = tasksServices;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiResponseWrapperFilter))]
        public async Task<ActionResult> GetTasks()
        {
            var tasks = await _tasksServices.GetAllTasksAsync();
           // return Ok(ApiResponseFactory.Success(tasks));
           return Ok(tasks);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ApiResponseWrapperFilter))]
        public async Task<ActionResult> GetTask(int id)
        {
            var task = await _tasksServices.GetTaskByIdAsync(id);
            if (task == null)
               // return NotFound(ApiResponseFactory.NotFound<object>());
               return NotFound();
           // return Ok(ApiResponseFactory.Success(task));
           return Ok(task);
        }

        [HttpPost]
        [ServiceFilter(typeof(ApiResponseWrapperFilter))]
        public async Task<ActionResult> CreateTask(TaskItemDto dto)
        {
            var created = await _tasksServices.CreateTaskAsync(dto);
           // return CreatedAtAction(nameof(GetTask), new { id = created.Id }, ApiResponseFactory.Created(created));
            return CreatedAtAction(nameof(GetTask), new { id = created.Id },created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItemDto dto)
        {
            if (id != dto.Id)
                return BadRequest(ApiResponseFactory.BadRequest<object>(new List<string> { "ID in URL and payload do not match." }));

            var updated = await _tasksServices.UpdateTaskAsync(dto);
            if (!updated)
                return NotFound(ApiResponseFactory.NotFound<object>());

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _tasksServices.DeleteTaskAsync(id);
            if (!deleted)
                return NotFound(ApiResponseFactory.NotFound<object>());

            return NoContent();
        }
        [HttpGet("filter")]
        public async Task<ActionResult> FilteredTasks(
           [FromQuery] string type,
           [FromQuery] int? userId = null)
        {
            switch (type.ToLower())
            {
         
                case "user":
                    if (userId == null)
                        return BadRequest(ApiResponseFactory.BadRequest<object>(
                            new List<string> { "userId is required when type is 'user'" }));
                    var userTasks = await _tasksServices.GetTasksByUserIdAsync(userId.Value);
                    return Ok(ApiResponseFactory.Success(userTasks));

                case "due-this-week":
                    var dueThisWeek = await _tasksServices.GetTasksDueThisWeekAsync();
                    return Ok(ApiResponseFactory.Success(dueThisWeek));

                case "overdue-or-incomplete":
                    var overdue = await _tasksServices.GetOverdueOrIncompleteTasksAsync();
                    return Ok(ApiResponseFactory.Success(overdue));

                case "completed-count":
                    var completed = await _tasksServices.GetCompletedTaskCountPerUserAsync();
                    return Ok(ApiResponseFactory.Success(completed));

                default:
                    return BadRequest(ApiResponseFactory.BadRequest<object>(
                        new List<string> { "Invalid type. Allowed values: user, due-this-week, overdue-or-incomplete, completed-count" }));
            }
        }

        //[HttpGet("user/{userId}")]
        //public async Task<ActionResult> GetTasksByUser(int userId)
        //{
        //    var tasks = await _tasksServices.GetTasksByUserIdAsync(userId);
        //    return Ok(ApiResponseFactory.Success(tasks));
        //}

        //[HttpGet("due-this-week")]
        //public async Task<ActionResult> GetTasksDueThisWeek()
        //{
        //    var tasks = await _tasksServices.GetTasksDueThisWeekAsync();
        //    return Ok(ApiResponseFactory.Success(tasks));
        //}

        //[HttpGet("overdue-or-incomplete")]
        //public async Task<ActionResult> GetOverdueOrIncompleteTasks()
        //{
        //    var tasks = await _tasksServices.GetOverdueOrIncompleteTasksAsync();
        //    return Ok(ApiResponseFactory.Success(tasks));
        //}

        //[HttpGet("completed-count")]
        //public async Task<ActionResult> GetCompletedTasksPerUser()
        //{
        //    var result = await _tasksServices.GetCompletedTaskCountPerUserAsync();
        //    return Ok(ApiResponseFactory.Success(result));
        //}
    }
}

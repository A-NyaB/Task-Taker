using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Task_Taker.Models;
using Task_Taker.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_Taker.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TaskController : ControllerBase
        {
            private readonly ITaskRepository _taskRepository;
            public TaskController(ITaskRepository taskRepository)
            {
                _taskRepository = taskRepository;
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_taskRepository.GetAllTasks());
            }

            [HttpGet("task/{taskId}")]
            public IActionResult GetTaskById(int taskId)
            {
                var task = _taskRepository.GetTaskById(taskId);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }

            [HttpGet("{userId}")]
            public IActionResult GetTasksByUser(int userId)
            {

                return Ok(_taskRepository.GetAllTasksByList(userId));
            }

            [HttpPost]
            public IActionResult Task(Task_Taker.Models.Task? task)
            {
                _taskRepository.Add(task);
                return CreatedAtAction("Get", new { id = task.Id }, task);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Task_Taker.Models.Task task)
            {
                if (id != task.Id)
                {
                    return BadRequest();
                }

                _taskRepository.EditTask(task);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _taskRepository.DeleteTask(id);
                return NoContent();
            }


        }
    }


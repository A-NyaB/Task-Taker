using Azure;
using Microsoft.AspNetCore.Mvc;
using Task_Taker.Repositories;
using Task_Taker.Models;


namespace Task_Taker.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
    public class TaskListController: ControllerBase
        {
            private readonly ITaskListRepository _taskListRepository;
            public TaskListController(ITaskListRepository taskListRepository)
            {
                _taskListRepository = taskListRepository;
            }
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_taskListRepository.GetAll());
            }

            [HttpPost]
            public IActionResult Post(TaskList taskList)
            {
                _taskListRepository.Add(taskList);
                return CreatedAtAction(
                    "Get", new { id = taskList.Id }, taskList);
            }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _taskListRepository.GetById(id);

                if (_taskListRepository == null)
                {
                    return NotFound($"Category with ID {id} not found");
                }

                _taskListRepository.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Server Error: {ex.Message}");
            }
        }
            [HttpPut("{id}")]
            public IActionResult UpdateTaskList(int id, TaskList taskList)
                {
                    if (id != taskList.Id)
                    {
                        return BadRequest();
                    }

                    _taskListRepository.UpdateTaskList(taskList);

                    return NoContent();
                }

                [HttpGet("{id}")]
                public IActionResult Get(int id)
                {
                    var taskList = _taskListRepository.GetTaskListById(id);
                    if (taskList == null)
                    {
                        return NotFound();
                    }
                    return Ok(taskList);
                }
            }
        }

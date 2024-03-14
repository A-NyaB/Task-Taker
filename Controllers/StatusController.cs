using Microsoft.AspNetCore.Mvc;
using Task_Taker.Repositories;
using Task_Taker.Models;

namespace Task_Taker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_statusRepository.GetAll());
        }
    }
}

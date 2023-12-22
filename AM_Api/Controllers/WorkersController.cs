using AM_Api.DataAccess;
using AM_Api.Models.Worker;
using AM_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : Controller
    {
        private readonly IWorkersService _workerManager;
        
        public WorkersController(IWorkersService workersService) {
            _workerManager = workersService;
        }

        [HttpGet("all")]
        public IEnumerable<Workers> GetAllWorkers()
        {
            return _workerManager.GetAllWorkers();
        }

        [HttpPost("register")]
        public IActionResult RegisterWorker([FromBody] WorkerRegistrationModel workerData)
        {
            var result = _workerManager.Register(workerData.Email, workerData.Password, workerData.Name, workerData.LastName);
            
            if (result.IsRegistered)
                return Ok(new { message = result.Message });
            else
                return BadRequest(new { message = result.Message });
        }
    }
}
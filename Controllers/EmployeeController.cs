using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autofac.Challenge.MethodDuration.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableRateLimiting("Concurrency")]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        public EmployeeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return _dataRepository.GetEmployees();
        }
    }
}

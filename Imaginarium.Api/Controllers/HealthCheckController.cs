using AutoMapper;
using Imaginarium.Data;
using Microsoft.AspNetCore.Mvc;

namespace Imaginarium.Controllers
{
    [ApiController]
    public class HealthCheckController : BaseController
    {
        private readonly ImaginariumDbContext _dbContex;
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ImaginariumDbContext dbContex, ILogger<HealthCheckController> logger, IMapper mapper) : base(mapper)
        {
            _dbContex = dbContex;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> HealthCheck()
        {
            var dbAvailable = await _dbContex.IsAvailable();

            return await _dbContex.IsAvailable() ? Ok("Imaginarium is fine!") : StatusCode(500, "Db is not available");
        }
    }
}

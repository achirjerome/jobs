using Microsoft.AspNetCore.Mvc;
using Jobs.DTO;
using Jobs.Services;
using Jobs.Data;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController: ControllerBase
    {
        public readonly IJobService _jobService;
        public readonly ApplicationDbContext dbContext;

        public JobsController(IJobService jobService, ApplicationDbContext dbContext )
        {
            _jobService = jobService;
            this.dbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        // GET: api/job?categoryName=Engineering&departmentName=IT
        [HttpGet("GetAllJobs")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobResponseDto>>> GetAllJobs(
        [FromQuery] string? categoryName = null,
        [FromQuery] string? departmentName = null,
        [FromQuery] bool? active = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

        

    }
}

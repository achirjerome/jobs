using Jobs.DTO;
using Jobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController: ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task ApplyToJobAsync(int jobId, ApplyJobDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationResponseDto> GetApplicationByIdAsync(int applicationId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("countsbyjob")]
        public async Task<IActionResult> GetApplicationCountsGroupedByJob()
        {
            var result = await _applicationService.GetApplicationCountsGroupedByJobAsync();
            return Ok(result);
        }

        public Task<IEnumerable<ApplicationCountByJobDto>> GetApplicationCountsGroupedByJobAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationResponseDto>> GetApplicationsForJobAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApplicationStatusAsync(int applicationId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }

}

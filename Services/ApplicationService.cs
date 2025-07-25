using Jobs.Data;
using Jobs.DTO;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task ApplyToJobAsync(int jobId, ApplyJobDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationResponseDto> GetApplicationByIdAsync(int applicationId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationCountByJobDto>> GetApplicationCountsGroupedByJobAsync()
        {
            var grouped = await _context.Applications
               .GroupBy(a => new { a.JobId, a.Job.Title })
               .Select(g => new ApplicationCountByJobDto
               {
                   JobId = g.Key.JobId,
                   JobTitle = g.Key.Title,
                   ApplicationCount = g.Count()
               }).ToListAsync();

            return grouped;
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

using Jobs.Data;
using Jobs.DTO;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateJobAsync(CreateJobDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<JobResponseDto>> GetAllJobsAsync()
        {
            
            return await _context.Jobs.Include(d=>d.Department).Where(r=>r.Active).Select(j => new JobResponseDto
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                Category = j.Category.Name,
                Department = j.Department.Name,
                StartDate = j.StartDate,
                ClosingDate = j.ClosingDate,
                Documents = j.Documents.Select(d => d.DocumentName).ToList()
            }).ToListAsync();
        }




        public async Task<JobResponseDto?> GetJobByIdAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateJobAsync(int jobId, UpdateJobDto dto)
        {
            throw new NotImplementedException();
        }
        
    }
}

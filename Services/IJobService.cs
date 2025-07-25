using Jobs.DTO;

namespace Jobs.Services
{
    public interface IJobService
    {
        // Admin posts a new job with title, description, category, dates, and required documents.
        Task CreateJobAsync(CreateJobDto dto);

        // Gets a list of all jobs, optionally filtered by category or date.      
        Task<IEnumerable<JobResponseDto>> GetAllJobsAsync();

        // Gets details of a single job by its ID.
        Task<JobResponseDto?> GetJobByIdAsync(int jobId);

        // Updates an existing job.
        Task UpdateJobAsync(int jobId, UpdateJobDto dto);

        
    }
}


using Jobs.DTO;

namespace Jobs.Services
{
    public interface IApplicationService
    {
        // Handles applying to a job: saves applicant info, qualifications, work experience, uploaded docs.
        // <param name="dto">Data submitted by the applicant</param>
        Task ApplyToJobAsync(int jobId, ApplyJobDto dto);

        // Retrieves all applications submitted for a specific job.        
        // <returns>A list of ApplicationResponseDto containing applicant details, documents, qualifications, and work history.</returns>
        Task<IEnumerable<ApplicationResponseDto>> GetApplicationsForJobAsync(int jobId);

        // Retrieves a single application by its unique ID.        
        // <returns>An ApplicationResponseDto with applicant data, documents, qualifications, and work history.</returns>
        Task<ApplicationResponseDto> GetApplicationByIdAsync(int applicationId);

        // Updates the status of an existing application (e.g., Pending → Shortlisted, Rejected).       
        // <param name="newStatus">The new status value to set (e.g., "Shortlisted", "Rejected").</param>
        Task UpdateApplicationStatusAsync(int applicationId, string newStatus);

        //Counts all applications for each job and returns a list of counts grouped by job.
        Task<IEnumerable<ApplicationCountByJobDto>> GetApplicationCountsGroupedByJobAsync();
    }
}

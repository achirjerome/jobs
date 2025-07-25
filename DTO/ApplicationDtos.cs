using System.ComponentModel.DataAnnotations;

namespace Jobs.DTO
{
    // For applicant to apply to a job
    public class ApplyJobDto
    {
        public int ApplicantId { get; set; }  
        // Uploaded files: each document as an IFormFile
        public List<IFormFile> UploadedDocuments { get; set; }
    }

    // For admin or applicant to view applications
    public class ApplicationResponseDto
    {
        public int Id { get; set; }
        [Required]
        public int JobId { get; set; }
        public int ApplicantId { get; set; }
        public DateTime AppliedAt { get; set; }
        public string Status { get; set; } // Pending, Shortlisted, Rejected, employed etc.

    }

    //admin to update status
    public class UpdateApplicationStatusDto
    {
        public string Status { get; set; }
    }

    //Count all applications for each job
    public class ApplicationCountByJobDto
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int ApplicationCount { get; set; }
    }
}

namespace Jobs.DTO
{

    // For creating a new job 
    public class CreateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string NeededQualification { get; set; }
        public string Category { get; set; } // E.g., "Technology", "Academic"
        public DateTime StartDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public List<string> Documents { get; set; }  // E.g., ["CV", "Cover Letter"]
    }

    // For updating an existing job 
    public class UpdateJobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string NeededQualification { get; set; }
        public DateTime? ClosingDate { get; set; }
        public List<string> Documents { get; set; }
    }

    // What applicants (or admin) see when querying jobs
    public class JobResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool? active { get; set; }
        public List<string> Documents { get; set; } = new List<string>();  // list of required document names
    }
}

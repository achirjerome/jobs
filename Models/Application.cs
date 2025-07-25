using System.ComponentModel.DataAnnotations;

namespace Jobs.Models
{
    public class Application
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public string ApplicantFirstName { get; set; }
        public string ApplicantSurName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Nationality { get; set; }
        public string StateofOrigin  { get; set; }
        public string LGA { get; set; } // Local Government Area
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime AppliedOn { get; set; }


        public string Status { get; set; } 

        // Navigation: uploaded documents like CV, Cover Letter
        public List<ApplicationDocument> UploadedDocuments { get; set; }

        // Navigation: applicant's qualifications (degrees, certificates)
        public List<Qualification> Qualifications { get; set; }

        // Navigation: applicant's previous work experience
        public List<WorkExperience> WorkExperiences { get; set; }

    }
}

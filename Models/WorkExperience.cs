using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }    // Foreign key
        [ForeignKey(nameof(ApplicationId))]
        public Application Application { get; set; }

        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

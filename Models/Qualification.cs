using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }  // Foreign key
        [ForeignKey(nameof(ApplicationId))]
        public Application Application { get; set; }

        public string Title { get; set; }          // e.g., "B.Sc. Computer Science"
        public string Institution { get; set; }    // e.g., "University of Lagos"
        public DateTime DateObtained { get; set; } // e.g., "2018-07-01"
    }
}

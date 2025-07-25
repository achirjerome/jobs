using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Jobs.Models
{
    public class Job
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(600)]
        public string Description { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation property
        public Department? Department { get; set; }
        public bool Active { get; set; } = true; //active or closed
       
        public List<Application> Applications { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public JobCategory Category { get; set; }

        // Add this navigation property:
        public ICollection<Document> Documents { get; set; } = new List<Document>();
   
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }
    }
}

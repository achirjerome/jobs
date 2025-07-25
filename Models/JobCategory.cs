namespace Jobs.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } // Admin, Technology, Academic, etc.
        public string Description { get; set; } // A brief description of the category
    }
}

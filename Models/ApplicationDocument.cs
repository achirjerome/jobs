namespace Jobs.Models
{
    public class ApplicationDocument
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        public string DocumentName { get; set; }
        public string FilePath { get; set; }

    }
}

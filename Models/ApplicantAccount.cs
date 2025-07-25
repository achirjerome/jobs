namespace Jobs.Models
{
    public class ApplicantAccount
    {
        public int Id { get; set; } 
        public string? Email { get; set; } 
        public string? PasswordHash { get; set; }
        public bool? IsEmailVerified { get; set; }
    }
}

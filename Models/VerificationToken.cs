namespace Jobs.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VerificationToken
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string TokenHash { get; set; }

        public DateTime ExpiryDateTime { get; set; }

        public int JobId { get; set; }
    }

}

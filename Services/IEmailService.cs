namespace Jobs.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);

        Task SendVerificationEmail(string toEmail, string verificationLink);
    }

}

using Jobs.Models;
using Jobs.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        using (var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
        {
            smtpClient.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
            smtpClient.EnableSsl = _smtpSettings.EnableSsl;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.UserName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }

    public async Task SendVerificationEmail(string toEmail, string verificationLink)
    {
        string subject = "Verify your email";
        string message = $"<p>Please verify your email by clicking this link: <a href='{verificationLink}'>Verify Email</a></p>";
        await SendEmailAsync(toEmail, subject, message);
    }
}

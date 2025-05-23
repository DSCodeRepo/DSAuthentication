using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var apiKey = _configuration["EmailSettings:SendGridApiKey"]; // Use the injected configuration
        if (string.IsNullOrEmpty(apiKey))
            throw new InvalidOperationException("SendGrid API Key is missing");

        var smtpClient = new SmtpClient("smtp.sendgrid.net")
        {
            Port = 587,
            Credentials = new NetworkCredential("apikey", apiKey),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("shahdhaval84@gmail.com"),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);
        await smtpClient.SendMailAsync(mailMessage);
    }
}
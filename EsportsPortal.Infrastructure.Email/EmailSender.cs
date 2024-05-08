using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace EsportsPortal.WebApi.Identity;

public class EmailSender(IOptions<EmailOptions> options) : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        using var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(options.Value.From);
        mailMessage.To.Add(new MailAddress(email));
        mailMessage.Subject = subject;
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = htmlMessage;

        using var client = new SmtpClient
        {
            DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
            PickupDirectoryLocation = Path.Combine(Directory.GetCurrentDirectory(), options.Value.PickupDirectoryLocation)
        };

        client.Send(mailMessage);

        return Task.CompletedTask;
    }
}

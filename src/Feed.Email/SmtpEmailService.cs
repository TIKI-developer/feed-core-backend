using Feed.Application.Interfaces;
using Feed.Application.Interfaces.Messages;
using Feed.Email.Options;
using Feed.Email.Templates;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Feed.Email;

internal sealed class SmtpEmailService(
    IOptions<EmailProviderOptions> options,
    EmailTemplateRenderer renderer)
    : IEmailService
{
    private readonly EmailProviderOptions _options = options.Value;

    public async Task SendAsync(
        string recipient,
        EmailMessage message)
    {
        var email = renderer.Render(message);

        using var smtp = new SmtpClient(_options.Host)
        {
            Port = _options.Port,
            EnableSsl = _options.EnableSsl,
            Credentials = new NetworkCredential(
                _options.Credentials.Address,
                _options.Credentials.Password)
        };

        using var mail = new MailMessage
        {
            From = new MailAddress(_options.Credentials.Address),
            Subject = email.Subject,
            Body = email.Html,
            IsBodyHtml = true
        };

        mail.To.Add(recipient);

        await smtp.SendMailAsync(mail);
    }
}

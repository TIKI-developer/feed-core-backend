using Feed.Application.Interfaces.Messages;

namespace Feed.Application.Interfaces;

public interface IEmailService
{
    Task SendAsync(string recipient, EmailMessage message);
}

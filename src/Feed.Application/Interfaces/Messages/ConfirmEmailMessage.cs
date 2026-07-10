namespace Feed.Application.Interfaces.Messages;

public record ConfirmEmailMessage(Uri ConfirmationUrl) : EmailMessage();

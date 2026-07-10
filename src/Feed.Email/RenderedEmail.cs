namespace Feed.Email;

internal sealed record RenderedEmail(
    string Subject,
    string Html);

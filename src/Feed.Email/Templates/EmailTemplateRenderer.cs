using Feed.Application.Interfaces.Messages;

namespace Feed.Email.Templates;

internal sealed class EmailTemplateRenderer(
    EmbeddedResourceProvider resources)
{
    public RenderedEmail Render(EmailMessage message)
    {
        var definition = TemplateDefinitions.Templates[message.GetType()];

        var html = resources.Get(definition.ResourceName);

        html = Replace(html, message);

        return new RenderedEmail(
            definition.Subject,
            html);
    }

    private static string Replace(
        string html,
        EmailMessage message)
    {
        return message switch
        {
            ConfirmEmailMessage m =>
                html.Replace(
                    "{{ConfirmationUrl}}",
                    m.ConfirmationUrl.ToString()),

            _ => throw new NotSupportedException()
        };
    }
}

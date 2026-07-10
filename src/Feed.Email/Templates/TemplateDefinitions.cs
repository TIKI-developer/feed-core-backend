using Feed.Application.Interfaces.Messages;

namespace Feed.Email.Templates;

internal static class TemplateDefinitions
{
    public static readonly IReadOnlyDictionary<Type, EmailTemplateDefinition> Templates =
        new Dictionary<Type, EmailTemplateDefinition>
        {
            {
                typeof(ConfirmEmailMessage),
                new(
                    "Confirm email",
                    "Templates.Resources.EmailConfirmation.html")
            },
        };
}

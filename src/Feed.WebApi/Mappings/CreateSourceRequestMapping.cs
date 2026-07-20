using Feed.Application.UseCases.Publications.Commands.CreateSource;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class CreateSourceRequestMapping
{
    public static CreateSourceCommand ToCommand(this CreateSourceRequest request)
    {
        return new CreateSourceCommand
        {
            Name = request.Body.Name,
            ExternalId = request.Body.ExternalId,
            SourceProviderName = request.Body.SourceProviderName,
        };
    }
}

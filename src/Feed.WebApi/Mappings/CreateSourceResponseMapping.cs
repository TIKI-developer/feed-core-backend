using Feed.Application.UseCases.Publications.Commands.CreateSource;
using Feed.WebApi.Responses;

namespace Feed.WebApi.Mappings;

public static class CreateSourceResponseMapping
{
    public static CreateSourceResponse ToResponse(this CreateSourceCommandResult result)
    {
        return new CreateSourceResponse
        {
            Id = result.Id
        };
    }
}

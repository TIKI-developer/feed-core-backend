using Feed.Application.UseCases.Publications.Commands.UpdateSource;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class UpdateSourceRequestMapping
{
    public static UpdateSourceCommand ToCommand(this UpdateSourceRequest request, Guid id)
    {
        return new UpdateSourceCommand
        {
            Id = id,
            Name = request.Body.Name
        };
    }
}

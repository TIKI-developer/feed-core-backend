using Feed.Application.UseCases.Dictionaries.Commands.CreateDictionary;
using Feed.WebApi.Responses;

namespace Feed.WebApi.Mappings;

public static class CreateDictionaryResponseMapping
{
    public static CreateDictionaryResponse ToResponse(this CreateDictionaryCommandResult result)
    {
        return new CreateDictionaryResponse
        {
            Id = result.Id
        };
    }
}

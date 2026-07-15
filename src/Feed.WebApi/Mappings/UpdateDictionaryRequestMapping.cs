using Feed.Application.UseCases.Dictionaries.Commands.UpdateDictionary;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class UpdateDictionaryRequestMapping
{
    public static UpdateDictionaryCommand ToCommand(this UpdateDictionaryRequest request, Guid id)
    {
        return new UpdateDictionaryCommand
        {
            Id = id,
            Name = request.Body.Name
        };
    }
}

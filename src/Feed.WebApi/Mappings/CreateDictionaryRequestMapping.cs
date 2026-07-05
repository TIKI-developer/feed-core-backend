using Feed.Application.UseCases.Dictionaries.Commands.CreateDictionar;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class CreateDictionaryRequestMapping
{
    public static CreateDictionaryCommand ToCommand(this CreateDictionaryRequest request)
    {
        return new CreateDictionaryCommand
        {
            Name = request.Name
        };
    }
}
using Feed.Application.UseCases.Dictionaries.Commands.AddWordsToDictionary;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class AddWordsToDictionaryRequestMapping
{
    public static AddWordsToDictionaryCommand ToCommand(this AddWordsToDictionaryRequest request, Guid dictionaryId)
    {
        return new AddWordsToDictionaryCommand
        {
            DictionaryId = dictionaryId,
            Words = request.Body.Words
        };
    }
}

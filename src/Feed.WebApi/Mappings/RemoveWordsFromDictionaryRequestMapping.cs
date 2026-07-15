using Feed.Application.UseCases.Dictionaries.Commands.RemoveWordsFromDictionary;
using Feed.WebApi.Requests;

namespace Feed.WebApi.Mappings;

public static class RemoveWordsFromDictionaryRequestMapping
{
    public static RemoveWordsFromDictionaryCommand ToCommand(this RemoveWordsFromDictionaryRequest request, Guid dictionaryId)
    {
        return new RemoveWordsFromDictionaryCommand
        {
            DictionaryId = dictionaryId,
            Words = request.Body.Words
        };
    }
}

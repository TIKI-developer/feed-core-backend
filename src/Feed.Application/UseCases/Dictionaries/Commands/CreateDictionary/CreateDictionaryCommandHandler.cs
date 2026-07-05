using Feed.Application.Interfaces;
using Feed.Application.UseCases.Dictionaries.Commands.CreateDictionar;
using Feed.Domain.Dictionaries.Entities;
using Mediator;

namespace Feed.Application.UseCases.Dictionaries.Commands.CreateDictionary;

internal sealed class CreateDictionaryCommandHandler
    (IDictionaryRepository dictionaryRepository)
    :
    ICommandHandler<CreateDictionaryCommand, CreateDictionaryCommandResult>
{
    public async ValueTask<CreateDictionaryCommandResult>
        Handle(CreateDictionaryCommand command, CancellationToken cancellationToken)
    {
        var dictionary = Dictionary.Create(command.Name);
        await dictionaryRepository.AddAsync(dictionary, cancellationToken);
        await dictionaryRepository.SaveChangesAsync(cancellationToken);

        return new CreateDictionaryCommandResult { Id = dictionary.Id };
    }
}

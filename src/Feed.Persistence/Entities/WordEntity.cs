namespace Feed.Persistence.Entities;

internal class WordEntity
{
    public required int Id { get; set; }
    public required string Value { get; set; }
    public ICollection<DictionaryWordEntity> DictionaryWords { get; set; } = [];
}

namespace Feed.Persistence.Entities;

internal class DictionaryWordEntity
{
    public Guid DictionaryId { get; set; }
    public int WordId { get; set; }

    public DictionaryEntity Dictionary { get; set; } = null!;
    public WordEntity Word { get; set; } = null!;
}

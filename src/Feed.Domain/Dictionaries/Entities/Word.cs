namespace Feed.Domain.Dictionaries.Entities;

public sealed class Word
{
    public int Id { get; private set; }
    public string Value { get; private set; }

    private Word(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public static Word Create(string value)
    {
        return new Word(0, value);
    }
    public static Word Restore(int id, string value)
    {
        return new Word(id, value);
    }
}

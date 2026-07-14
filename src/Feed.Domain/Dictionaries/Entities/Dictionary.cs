using Feed.Domain.Shared.ValueObjects;

namespace Feed.Domain.Dictionaries.Entities;

public class Dictionary
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<int> Words => _words.AsReadOnly();
    public Timestamps Timestamps { get; private set; }

    private readonly HashSet<int> _words;

    private Dictionary(
        Guid id,
        string name,
        ICollection<int> words,
        Timestamps timestamps)
    {
        Id = id;
        Name = name;
        _words = words?.ToHashSet() ?? [];
        Timestamps = timestamps;
    }

    public static Dictionary Create(string name, ICollection<int>? words = null)
    {
        return new Dictionary(Guid.NewGuid(), name, words ?? [], Timestamps.Create());
    }

    public static Dictionary Restore(Guid id, string name, ICollection<int> words, Timestamps timestamps)
    {
        return new Dictionary(id, name, words, timestamps);
    }

    public void Update(string name)
    {
        Name = name;
        Timestamps.Touch();
    }

    public void AddWords(IEnumerable<int> words)
    {
        foreach (var word in words)
        {
            _words.Add(word);
        }

        Timestamps.Touch();
    }

    public void RemoveWords(IEnumerable<int> words)
    {
        foreach (var word in words)
        {
            _words.Remove(word);
        }

        Timestamps.Touch();
    }
}

namespace Feed.Domain.Dictionaries;

public class Dictionary
{

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();
    private readonly HashSet<Word> _words;

    private Dictionary(Guid id, string name, ICollection<Word> words)
    {
        Id = id;
        Name = name;
        _words = words?.ToHashSet() ?? [];
    }

    public static Dictionary Create(string name, ICollection<Word>? words = null)
    {
        return new Dictionary(Guid.NewGuid(), name, words ?? []);
    }

    public static Dictionary Restore(Guid id, string name, ICollection<Word> words)
    {
        return new Dictionary(id, name, words);
    }

    public void Update(string name)
    {
        Name = name;
    }

    public void AddWords(IEnumerable<Word> words)
    {
        foreach (var word in words)
        {
            _words.Add(word);
        }
    }

    public void RemoveWords(IEnumerable<Word> words)
    {
        foreach (var word in words)
        {
            _words.Remove(word);
        }
    }
}
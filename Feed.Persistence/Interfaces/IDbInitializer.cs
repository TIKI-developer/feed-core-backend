namespace Feed.Persistence.Interfaces;

public interface IDbInitializer
{
    Task InitializeAsync();
}
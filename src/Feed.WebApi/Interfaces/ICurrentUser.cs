namespace Feed.WebApi.Interfaces;

public interface ICurrentUser
{
    Guid Id { get; }
    string Email { get; }
    List<Guid> Roles { get; }
}
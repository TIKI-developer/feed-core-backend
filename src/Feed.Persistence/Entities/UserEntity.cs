using Feed.Domain.Shared.ValueObjects;

namespace Feed.Persistence.Entities;

internal class UserEntity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public FullName? FullName { get; set; }
    public Email? Email { get; set; }
    public required Password Password { get; set; }
    public required ICollection<Guid> Roles { get; set; }
}

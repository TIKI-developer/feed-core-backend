using Feed.Domain.Users.Entities;

namespace Feed.Application.Interfaces;

public interface IAccessTokenService
{
    string Generate(User user);
}
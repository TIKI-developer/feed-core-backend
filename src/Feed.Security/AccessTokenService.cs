using Feed.Application.Interfaces;
using Feed.Domain.Users.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Feed.Security;

public class AccessTokenService(IOptions<AccessTokenOptions> options) : IAccessTokenService
{
    private readonly AccessTokenOptions _options = options.Value;

    public string Generate(User user)
    {
        var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
        }

        var signingCredentials = new SigningCredentials(

                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtOptions.SecretKey)),

                SecurityAlgorithms.HmacSha256
            );

        var token = new JwtSecurityToken(

                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.JwtOptions.ExpiresHours)
            );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
}

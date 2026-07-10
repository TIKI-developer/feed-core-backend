using Feed.WebApi.Interfaces;
using System.Security.Claims;

namespace Feed.WebApi.Controllers;

public class CurrentUser(IHttpContextAccessor context) : ICurrentUser
{
    private readonly IHttpContextAccessor _context = context;

    private ClaimsPrincipal User => _context.HttpContext?.User!;

    public Guid Id => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    public string Email => User.FindFirstValue(ClaimTypes.Email)!;
    public List<Guid> Roles => User.FindAll(ClaimTypes.Role).Select(x => Guid.Parse(x.Value)).ToList();
}
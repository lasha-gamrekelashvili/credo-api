using System.Security.Claims;

namespace credo_api.Context;

public interface IUserContextService
{
    Guid GetCurrentUserId();

}

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        if (_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier) is { } userClaim)
        {
            return Guid.Parse(userClaim.Value);
        }

        throw new InvalidOperationException("User is not authenticated");
    }
    
}
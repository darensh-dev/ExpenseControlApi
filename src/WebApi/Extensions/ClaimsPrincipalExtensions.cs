namespace ExpenseControlApi.Extensions;
using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static bool TryGetUserId(this ClaimsPrincipal user, out long userId)
    {
        userId = 0;
        var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return long.TryParse(id, out userId);
    }

    public static long GetUserId(this ClaimsPrincipal user)
    {
        if (TryGetUserId(user, out var id)) return id;
        throw new UnauthorizedAccessException("Invalid user ID in token.");
    }
}

using System.Security.Claims;

namespace ExpenseControlApi.Utils;

public static class UserUtils

{
    // var userId = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    public static bool TryGetUserId(ClaimsPrincipal user, out long userId)
    {
        userId = 0;
        var userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return long.TryParse(userIdString, out userId);
    }
}

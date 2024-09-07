using System;
using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipleExtensions
{
public static string GetUserName(this ClaimsPrincipal user)
{
    var username = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if(username == null)
    {
        throw new Exception("Cannot get username");
    }

    return username;
}
}

using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;
public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
    IConfiguration configuration)
    {
        var tokenKey = configuration["TokenKey"] ?? throw new Exception("Token not found");
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(option => option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenKey)),
    ValidateIssuer = false,
    ValidateAudience = false
});  
 return services;
    }
}

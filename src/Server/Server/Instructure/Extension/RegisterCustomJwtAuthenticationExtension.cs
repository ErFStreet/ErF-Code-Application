using Microsoft.AspNetCore.Authorization;

namespace Server.Instructure.Extension;

public static class RegisterCustomJwtAuthenticationExtension
{
    public static void RegisterJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,

                     ValidateAudience = true,

                     ValidateLifetime = true,

                     ValidateIssuerSigningKey = true,

                     IssuerSigningKey =
                           new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                                (configuration["JwtSettings:Key"]!))
                 };
             });
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Jwt;

public static class JwtConfiguration
{
    /// <summary>
    ///
    /// </summary>
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                JwtBearerDefaults.AuthenticationScheme,
                options =>
                {
                    options.Authority = jwtOptions.Authority;
                    options.Audience = jwtOptions.Audience;
                    options.TokenValidationParameters.ValidateAudience = true;
                }
            );

        services.AddAuthorization(options =>
        {
            foreach (var item in jwtOptions.Policies)
            {
                options.AddPolicy(
                    item.Name,
                    policy =>
                    {
                        if (item.RequireAuthenticatedUser)
                            policy.RequireAuthenticatedUser();

                        policy.RequireClaim("scope", item.AllowedScopes);
                    }
                );
            }
        });
    }
}

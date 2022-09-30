using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Jwt
{
    public static class JwtConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
          {
              options.Authority = configuration["Jwt:Authority"];
              options.TokenValidationParameters.ValidateAudience = false;
          });

            var allowedScope = configuration["Jwt:AllowedScope"];
            services.AddAuthorization(options =>
                    options.AddPolicy("ApiScope", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("scope", allowedScope);
                    })
                );
        }


    }
}

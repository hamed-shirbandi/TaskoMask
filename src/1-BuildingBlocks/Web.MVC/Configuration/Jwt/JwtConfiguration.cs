using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

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

            var audience = configuration["Jwt:Audience"];
            if (!string.IsNullOrEmpty(audience))
            {
                services.AddAuthorization(options =>
                    options.AddPolicy("ApiScope", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("scope", audience);
                    }));
            }
        }


    }
}

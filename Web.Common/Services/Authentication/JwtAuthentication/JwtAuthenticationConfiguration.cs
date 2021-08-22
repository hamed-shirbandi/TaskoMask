using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TaskoMask.Web.Common.Services.Authentication.Models;

namespace TaskoMask.Web.Common.Services.Authentication.JwtAuthentication
{
    public static class JwtAuthenticationConfiguration
    {

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,Action<JwtAuthenticationOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            
            services.Configure(setupAction);
            services.TryAddSingleton<IJwtAuthenticationService, JwtAuthenticationService>();

            var jwtOptions = services.BuildServiceProvider().GetRequiredService<IOptions<JwtAuthenticationOptions>>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtOptions.Value.Issuer,
                        ValidAudience = jwtOptions.Value.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key)),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });



            return services;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Identity.Api.Domain.Entities;
using TaskoMask.Services.Identity.Api.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.AspNetIdentity;

internal static class AspNetIdentityExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddAspNetIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, IdentityRole<string>>().AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            configuration.GetSection("Identity:Options").Bind(options);
        });
    }
}

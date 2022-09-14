using Microsoft.AspNetCore.Identity;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Identity.Api.Configuration
{
    internal static class AspNetIdentityExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddAspNetIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                configuration.GetSection("Identity:Options").Bind(options);
            });
        }
    }
}

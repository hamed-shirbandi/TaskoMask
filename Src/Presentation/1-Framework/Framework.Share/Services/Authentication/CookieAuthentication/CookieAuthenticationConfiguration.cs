using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication
{
    public static class CookieAuthenticationConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddCookieAuthentication(this IServiceCollection services, IWebHostEnvironment env, Action<Models.CookieAuthenticationOptions> setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            services.Configure(setupAction);

            var options = services.BuildServiceProvider().GetRequiredService<IOptions<Models.CookieAuthenticationOptions>>();

          //  services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICookieAuthenticationService, CookieAuthenticationService>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(option =>
            {
                option.Cookie.SecurePolicy = CookieSecurePolicy.None;// env.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                option.Cookie.Name = options.Value.CookieName;
                option.Cookie.HttpOnly = options.Value.CookieHttpOnly;
                option.Cookie.SameSite = SameSiteMode.Lax;
                option.LoginPath = options.Value.LoginPath;
                option.LogoutPath = options.Value.LogoutPath;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(options.Value.ExpireFromMinute);
                option.SlidingExpiration = options.Value.SlidingExpiration;
            });
        }
    }
}

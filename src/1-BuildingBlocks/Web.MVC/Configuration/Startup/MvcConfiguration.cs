using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.CookieAuthentication;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Captcha;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static  class MvcConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddMvcPreConfigured(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllersWithViews();
            services.AddDNTCaptchaPreConfigured();
            services.AddCookieAuthentication(env,options =>
            {
                configuration.GetSection("Authentication").Bind(options);
            });
            services.AddCommonServices(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseMvcPreConfigured(this IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Unknown");
                app.UseHsts();
            }

            app.UseCommonServices(serviceProvider, env);
           
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }

    }
}

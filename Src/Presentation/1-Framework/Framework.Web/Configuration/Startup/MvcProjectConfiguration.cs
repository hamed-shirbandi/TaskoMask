using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication;
using TaskoMask.Presentation.Framework.Web.Configuration.Captcha;

namespace TaskoMask.Presentation.Framework.Web.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static  class MvcProjectConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void MvcProjectConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllersWithViews();
            services.AddDNTCaptchaPreConfigured();
            services.AddCookieAuthentication(env,options =>
            {
                configuration.GetSection("Authentication").Bind(options);
            });
            services.AddCommonConfigureServices(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void MvcProjectConfigure(this IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Unknown");
                app.UseHsts();
            }

            app.UseCommonConfigure(serviceProvider, env);
           
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }

    }
}

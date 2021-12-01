using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskoMask.Web.Common.Configuration.Captcha;
using TaskoMask.Web.Common.Services.Authentication.CookieAuthentication;

namespace TaskoMask.Web.Common.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static  class MvcConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void MvcConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
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
        public static void MvcConfigure(this IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
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

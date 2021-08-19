using DNTCaptcha.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace TaskoMask.Web.Common.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static  class MvcConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider MvcConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllersWithViews();
            services.AddDNTCaptchaPreConfigured();
            return services.AddCommonConfigureServices(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void MvcConfigure(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Unknown");
                app.UseHsts();
            }

            app.UseCommonConfigure(serviceScopeFactory,env);
           
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }



    }
}

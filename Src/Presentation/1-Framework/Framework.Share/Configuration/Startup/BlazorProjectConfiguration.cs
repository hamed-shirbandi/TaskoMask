using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskoMask.Presentation.Framework.Share.Services.Authentication.CookieAuthentication;

namespace TaskoMask.Presentation.Framework.Share.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static  class BlazorProjectConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void BlazorProjectConfigureServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCookieAuthentication(env,options =>
            {
                configuration.GetSection("Authentication").Bind(options);
            });
            services.AddSharedConfigureServices(configuration.GetValue<string>("Url:UserPanelAPI"));
        }



        /// <summary>
        /// 
        /// </summary>
        public static void BlazorProjectConfigure(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }

    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskoMask.Web.Common.Configuration.Swagger;
using TaskoMask.Web.Common.Services.Authentication.CookieAuthentication;
using TaskoMask.Web.Common.Services.Authentication.JwtAuthentication;

namespace TaskoMask.Web.Common.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider WebApiConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllers();
            services.AddSwaggerPreConfigured(options =>
            {
                configuration.GetSection("Swagger").Bind(options);
            });
            services.AddJwtAuthentication(options =>
            {
                configuration.GetSection("Jwt").Bind(options);
            });
            return services.AddCommonConfigureServices(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void WebApiConfigure(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwaggerPreConfigured();
            app.UseCommonConfigure(serviceScopeFactory, env);

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }


    }
}

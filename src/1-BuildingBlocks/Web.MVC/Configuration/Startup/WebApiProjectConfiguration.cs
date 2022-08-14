using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.JwtAuthentication;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Swagger;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static class WebApiProjectConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddWebApiProjectConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllers()
               //prevent auto validate on model binding
               .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

            services.AddSwaggerPreConfigured(options =>
            {
                configuration.GetSection("Swagger").Bind(options);
            });
            services.AddJwtAuthentication(options =>
            {
                configuration.GetSection("Jwt").Bind(options);
            });
            services.AddCommonConfigureServices(configuration);

            services.AddCors();

        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseWebApiProjectConfigure(this IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwaggerPreConfigured();
            app.UseCommonConfigure(serviceProvider, env);

            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
        }


    }
}

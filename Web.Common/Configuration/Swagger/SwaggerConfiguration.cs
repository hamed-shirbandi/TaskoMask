using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace TaskoMask.Web.Common.Configuration.Swagger
{
    public static class DNTCaptchaConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddSwaggerPreConfigured(this IServiceCollection services, Action<SwaggerOptions> setupAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));

            services.Configure(setupAction);

            var options = services.BuildServiceProvider().GetRequiredService<IOptions<SwaggerOptions>>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                //Hide some unwanted methods from documentation
                c.DocumentFilter<SwaggerHideInDocsFilter>();

                c.SwaggerDoc(options.Value.Version, new OpenApiInfo { Title = options.Value.Title, Version = options.Value.Version });

                foreach (var includeXmlComment in options.Value.IncludeXmlComments.Split(","))
                    c.IncludeXmlComments(string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, includeXmlComment));

            });


            return services;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IApplicationBuilder UseSwaggerPreConfigured(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            var options = app.ApplicationServices.GetRequiredService<IOptions<SwaggerOptions>>();
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/" + options.Value.Version + "/swagger.json", options.Value.Version);
            });


            return app;
        }


    }
}

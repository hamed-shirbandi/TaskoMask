using DNTCaptcha.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using TaskoMask.Web.Common.Configuration.Helpers;

namespace TaskoMask.Web.Common.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static  class PreConfiguredServices
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddDNTCaptchaPreConfigured(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDNTCaptcha(options =>
            {
                // options.UseSessionStorageProvider() // -> It doesn't rely on the server or client's times. Also it's the safest one.
                // options.UseMemoryCacheStorageProvider() // -> It relies on the server's times. It's safer than the CookieStorageProvider.
                options.UseCookieStorageProvider() // -> It relies on the server and client's times. It's ideal for scalability, because it doesn't save anything in the server's memory.
                                                   // .UseDistributedCacheStorageProvider() // --> It's ideal for scalability using `services.AddStackExchangeRedisCache()` for instance.
                                                   // .UseDistributedSerializationProvider()

                // Don't set this line (remove it) to use the installed system's fonts (FontName = "Tahoma").
                // Or if you want to use a custom font, make sure that font is present in the wwwroot/fonts folder and also use a good and complete font!
                .AbsoluteExpiration(minutes: 7)
                .ShowThousandsSeparators(false)
                .WithEncryptionKey("TaskoMask!")
                .InputNames(// This is optional. Change it if you don't like the default names.
                    new DNTCaptchaComponent
                    {
                        CaptchaHiddenInputName = "DNT_CaptchaText",
                        CaptchaHiddenTokenName = "DNT_CaptchaToken",
                        CaptchaInputName = "DNT_CaptchaInputText"
                    })
                .Identifier("dnt_Captcha")// This is optional. Change it if you don't like its default name.
                ;
            });

        }



        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddSwaggerPreConfigured(this IServiceCollection services, Action<SwaggerOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

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
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = app.ApplicationServices.GetRequiredService<IOptions<SwaggerOptions>>();
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));

            }

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

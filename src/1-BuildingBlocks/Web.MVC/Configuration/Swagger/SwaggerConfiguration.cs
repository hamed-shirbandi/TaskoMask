using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Swagger
{
    public static class SwaggerConfiguration
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
                c.EnableAnnotations();

                //Hide some unwanted methods from documentation
                c.DocumentFilter<SwaggerHideInDocsFilter>();
                //swagger doc info
                c.SwaggerDoc(options.Value.Version, new OpenApiInfo { Title = options.Value.Title, Version = options.Value.Version });
                //include xml comments from xml files referred in appsetting
                foreach (var includeXmlComment in options.Value.IncludeXmlComments.Split(","))
                    try { c.IncludeXmlComments(string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, includeXmlComment)); } catch { }

                //define Bearer security
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                //add Bearer input to swagger ui to authorize by a jwt token that get from login api
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                    }
                });
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
                //redirect root url to swagger ui
                c.RoutePrefix = "";
            });


            return app;
        }


    }
}

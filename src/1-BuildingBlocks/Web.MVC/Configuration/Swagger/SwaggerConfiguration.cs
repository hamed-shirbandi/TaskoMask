using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerPreConfigured(this IServiceCollection services, Action<SwaggerOptions> setupAction)
    {
        ArgumentNullException.ThrowIfNull(services);

        ArgumentNullException.ThrowIfNull(setupAction);

        services.Configure(setupAction);

        var options = services.BuildServiceProvider().GetRequiredService<IOptions<SwaggerOptions>>();

        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();

            c.DocumentFilter<SwaggerHideInDocsFilter>();

            c.SwaggerDoc(options.Value.Version, new OpenApiInfo { Title = options.Value.Title, Version = options.Value.Version });

            var xmlFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml");

            foreach (var xmlFile in xmlFiles)
                c.IncludeXmlComments(xmlFile);

            c.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                }
            );

            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                        },
                        Array.Empty<string>()
                    },
                }
            );
        });
        return services;
    }

    /// <summary>
    ///
    /// </summary>
    public static IApplicationBuilder UseSwaggerPreConfigured(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var options = app.ApplicationServices.GetRequiredService<IOptions<SwaggerOptions>>();

        ArgumentNullException.ThrowIfNull(options);

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

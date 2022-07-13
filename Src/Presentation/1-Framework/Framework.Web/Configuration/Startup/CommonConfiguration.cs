using FluentValidation;
using Infrastructure.CrossCutting.IoC;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCache.Core;
using TaskoMask.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Application.Core.Behaviors;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Mapper;
using TaskoMask.Application.Workspace.Organizations.Commands.Validations;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Infrastructure.Data.WriteModel.DataProviders;
using TaskoMask.Presentation.Framework.Share.Configuration.Startup;
using TaskoMask.Infrastructure.Data.ReadModel.DataProviders;
using TaskoMask.Domain.Share.Services;
using TaskoMask.Presentation.Framework.Web.Services.Authentication;
using TaskoMask.Presentation.Framework.Web.Services.Cookie;

namespace TaskoMask.Presentation.Framework.Web.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static class CommonConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddCommonConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSharedConfigureServices();


            services.AddHttpContextAccessor();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<ICookieService, CookieService>();

            services.AddScoped(sp => new HttpClient
            {
                //default base address for calling HttpClient
                //you can use IHttpClientServices to make HttpClient requests
                //if you use IHttpClientServices you can change the base address by SetBaseAddress method if needed
                BaseAddress = new Uri(configuration.GetValue<string>("Url:UserPanelAPI"))
            });

            services.AddMediatR(typeof(BoardBaseCommand));

            services.AddExceptionHandlers();

            services.AddBehaviors();

            services.AddAutoMapperSetup();

            //Load all fluent validation to use in ValidationBehaviour
            services.AddValidatorsFromAssembly(typeof(CreateOrganizationCommandValidation).Assembly);

            services.AddAutoMapperSetup();

            services.AddRedisCache(options =>
            {
                configuration.GetSection("RedisCache").Bind(options);
            });

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.ConfigureIocContainer();

        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseCommonConfigure(this IApplicationBuilder app, IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            WriteDbInitialization.Initial(serviceProvider);
            ReadDbInitialization.Initial(serviceProvider);
            WriteDbSeedData.SeedEssentialData(serviceProvider);

            app.UseHttpsRedirection();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddBehaviors(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddScoped<INotificationHandler<IDomainEvent>, EventStoringBehavior>();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddExceptionHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(ApplicationExceptionsHandler<,,>));
        }


    }
}

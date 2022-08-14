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
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Services.Monolith.Application.Core.Behaviors;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.Services.Monolith.Application.Mapper;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Validations;
using TaskoMask.Services.Monolith.Domain.Core.Events;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DataProviders;
using TaskoMask.Services.Monolith.Domain.Core.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Cookie;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.Startup
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

            services.AddHttpContextAccessor();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddScoped<ICookieService, CookieService>();
            services.AddMediatR(typeof(BoardBaseCommand));
            services.AddExceptionHandlers();
            services.AddBehaviors();
            services.AddAutoMapperSetup();
            //Load all fluent validation to use in ValidationBehaviour
            services.AddValidatorsFromAssembly(typeof(AddOrganizationValidation).Assembly);
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
            WriteDbSeedData.Seed(serviceProvider);

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

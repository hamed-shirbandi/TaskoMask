using FluentValidation;
using Infrastructure.CrossCutting.Ioc;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCache.Core;
using System;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Core.Behaviors;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Mapper;
using TaskoMask.Application.Organizations.Commands.Validations;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Infrastructure.Data.DataProviders;

namespace TaskoMask.Web.Common.Configuration.Startup
{

    /// <summary>
    /// 
    /// </summary>
    public static  class CommonConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider AddCommonConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

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

            return services.ConfigureIocContainer(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddBehaviors(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddScoped<INotificationHandler<IDomainEvent>, EventStoringBehavior>();

        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddExceptionHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(ApplicationExceptionsHandler<,,>));
        }



        /// <summary>
        /// 
        /// </summary>
        public static void UseCommonConfigure(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
           
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            serviceScopeFactory.InitialMongoDb();
            serviceScopeFactory.MongoDbSeedData();
            app.UseHttpsRedirection();

  
        }



    }
}

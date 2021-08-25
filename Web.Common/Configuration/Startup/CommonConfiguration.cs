using FluentValidation;
using Infrastructure.CrossCutting.Ioc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCache.Core;
using System;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Mapper;
using TaskoMask.Application.Organizations.Commands.Validations;
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

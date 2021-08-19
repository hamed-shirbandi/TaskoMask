using Infrastructure.CrossCutting.Ioc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Mapper;
using TaskoMask.Infrastructure.CrossCutting.Identity;
using TaskoMask.Infrastructure.Data.DataProviders;

namespace TaskoMask.Web.Common.Configuration
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

            services.AddMediatR(typeof(BoardCommand));
            services.AddIdentityConfiguration(configuration);
            services.AddAutoMapperSetup();

            return services.ConfigureIocContainer(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void WebApiConfigure(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            serviceScopeFactory.InitialMongoDb();
            serviceScopeFactory.MongoDbSeedData();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
        }


    }
}

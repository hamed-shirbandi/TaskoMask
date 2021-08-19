using DNTCaptcha.Core;
using Infrastructure.CrossCutting.Ioc;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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
    public static  class MvcConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider MvcConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddControllersWithViews();

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
                .WithEncryptionKey("This is my secure key!")
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

            return services.AddCommonConfigureServices(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void MvcConfigure(this IApplicationBuilder app, IServiceScopeFactory serviceScopeFactory, IWebHostEnvironment env)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Unknown");
                app.UseHsts();
            }

            app.UseCommonConfigure(serviceScopeFactory,env);
           
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }



    }
}

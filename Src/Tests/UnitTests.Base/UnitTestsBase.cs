using Infrastructure.CrossCutting.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace TaskoMask.UnitTests.Base
{

    public class UnitTestsBase
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public UnitTestsBase()
        {
            ServiceProvider = GetServiceProvider();

        }

        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                            .Build();

            services.AddSingleton<IConfiguration>(provider => { return configuration; });

              services.ConfigureIocContainer();
            
            return services.BuildServiceProvider();
        }






        /// <summary>
        /// Creates an IServiceScope which contains an IServiceProvider used to resolve dependencies from a newly created scope and then runs an associated callback.
        /// </summary>
        protected void RunScopedService<TService, TContext>(IServiceProvider serviceProvider, Action<TContext, TService> callback)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TContext>();

                callback(context, serviceScope.ServiceProvider.GetRequiredService<TService>());
                if (context is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        /// <summary>
        /// Creates an IServiceScope which contains an IServiceProvider used to resolve dependencies from a newly created scope and then runs an associated callback.
        /// </summary>
        protected void RunScopedService<TService>(IServiceProvider serviceProvider, Action<TService> callback)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TService>();
                callback(context);
                if (context is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        /// <summary>
        /// Creates an IServiceScope which contains an IServiceProvider used to resolve dependencies from a newly created scope and then runs an associated callback.
        /// </summary>
        protected TResult RunScopedService<TResult, TService>(IServiceProvider serviceProvider, Func<TService, TResult> callback)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TService>();
                return callback(context);
            }
        }


    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Infrastructure.Data.ReadModel.DataProviders;
using TaskoMask.Infrastructure.Data.WriteModel.DataProviders;
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

namespace TaskoMask.Application.Tests.Integration.TestData
{
    public abstract class TestsBase:IDisposable
    {
        protected IServiceProvider ServiceProvider { get; private set; }


        /// <summary>
        /// Run before each test method
        /// </summary>
        public TestsBase()
        {
            ServiceProvider = GetServiceProvider();
        }



        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                                //Copy from AdminPanel project during the build event
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .AddJsonFile("appsettings.Development.json", reloadOnChange: true, optional: false)
                                .Build();
            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            services.AddCommonConfigureServices(configuration);

            var serviceProvider = services.BuildServiceProvider();

            WriteDbInitialization.Initial(serviceProvider);
            ReadDbInitialization.Initial(serviceProvider);
            WriteDbSeedData.SeedEssentialData(serviceProvider);

            return serviceProvider;
        }



        /// <summary>
        /// Run after each test method
        /// </summary>
        public void Dispose()
        {
            WriteDbInitialization.DropDatabase(ServiceProvider);
            ReadDbInitialization.DropDatabase(ServiceProvider);
        }
    }
}

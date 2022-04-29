using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Infrastructure.Data.ReadModel.DataProviders;
using TaskoMask.Infrastructure.Data.WriteModel.DataProviders;
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

namespace TaskoMask.Application.Tests.Integration.TestData
{
    public class TestsBaseFixture : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;


        /// <summary>
        ///
        /// </summary>
        public TestsBaseFixture()
        {
            _serviceProvider = GetServiceProvider();
            InitializeDatabases();
        }



        /// <summary>
        /// 
        /// </summary>
        public T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }



        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        private void InitializeDatabases()
        {
            WriteDbInitialization.Initial(_serviceProvider);
            ReadDbInitialization.Initial(_serviceProvider);
            WriteDbSeedData.SeedEssentialData(_serviceProvider);
        }



        /// <summary>
        /// 
        /// </summary>
        private void DropDatabases()
        {
            WriteDbInitialization.DropDatabase(_serviceProvider);
            ReadDbInitialization.DropDatabase(_serviceProvider);
        }



        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            DropDatabases();
        }
    }
}

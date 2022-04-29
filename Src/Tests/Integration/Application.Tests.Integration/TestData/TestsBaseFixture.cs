using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Infrastructure.Data.ReadModel.DataProviders;
using TaskoMask.Infrastructure.Data.WriteModel.DataProviders;
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

namespace TaskoMask.Application.Tests.Integration.TestData
{
    /// <summary>
    /// If you want to share TestsBaseFixture for all test methods in a Test Class
    /// You just need to Inherit from IClassFixture<TestsBaseFixture> for that class
    /// And get TestsBaseFixture as a parameter in test class constructor
    /// So the TestsBaseFixture initialize before all test methods in that test class and then dispose after all tests run
    /// *But*
    /// If you want TestsBaseFixture to be initialized and disposed for each test method
    /// You just need to  Inherit from TestsBaseFixture for that class
    /// So the TestsBaseFixture initialize before each test method and then dispose after that test run
    /// </summary>
    public class TestsBaseFixture : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<string, string> _memorise;

        /// <summary>
        ///
        /// </summary>
        public TestsBaseFixture()
        {
            _memorise = new Dictionary<string, string>();
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
        public void SaveToMemeory(string key, string value)
        {
            _memorise.Add(key, value);
        }



        /// <summary>
        /// 
        /// </summary>
        public string GetFromMemeory(string key)
        {
            var memory= _memorise.FirstOrDefault(m => m.Key == key);
            return memory.Value;
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

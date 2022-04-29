using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskoMask.Infrastructure.Data.ReadModel.DataProviders;
using TaskoMask.Infrastructure.Data.WriteModel.DataProviders;
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

namespace TaskoMask.Application.Tests.Integration.TestData.Fixtures
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
    public abstract class TestsBaseFixture : IDisposable
    {
        #region Fields

        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<string, string> _memorise;

        #endregion

        #region Ctor

        public TestsBaseFixture(string dbNameSuffix)
        {
            _memorise = new Dictionary<string, string>();
            _serviceProvider = GetServiceProvider(dbNameSuffix);
            InitializeDatabases();
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// Get required services for each service
        /// </summary>
        public T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }


        /// <summary>
        /// Save data across all of the tests that fixture is shared between
        /// Use it when a test need a data from previous tests
        /// </summary>
        public void SaveToMemeory(string key, string value)
        {
            _memorise.Add(key, value);
        }



        /// <summary>
        /// Get data by its key
        /// Use it when a test need a data from previous tests
        /// </summary>
        public string GetFromMemeory(string key)
        {
            _memorise.TryGetValue(key, out string value);
            return value;
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private static IServiceProvider GetServiceProvider(string dbNameSuffix)
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                                //Copy from AdminPanel project during the build event
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .AddJsonFile("appsettings.Development.json", reloadOnChange: true, optional: false)
                                .AddInMemoryCollection(new[]
                                {
                                   new KeyValuePair<string,string>("Mongo:Write:Database", $"TaskoMask_WriteDB_Test_{dbNameSuffix}"),
                                   new KeyValuePair<string,string>("Mongo:Read:Database", $"TaskoMask_ReadDB_Test_{dbNameSuffix}"),
                                })
                                .Build();
            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            services.AddCommonConfigureServices(configuration);

            var serviceProvider = services.BuildServiceProvider();

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


        #endregion

        #region Dispose


        /// <summary>
        /// Dispose all resources that fixture used for tests
        /// </summary>
        public void Dispose()
        {
            DropDatabases();
        }


        #endregion
    }
}

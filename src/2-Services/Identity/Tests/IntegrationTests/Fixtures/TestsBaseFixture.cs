using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Infrastructure.EntityFramework;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Identity.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Identity.IntegrationTests.Fixtures
{
    /// <summary>
    /// Each test class must have its own fixture and each fixture initialize and dispose a unique database
    /// So, we have control over parallel tests run and lower cost for creating database for tests
    /// ------------------* But *-----------------------------------------------
    /// If you want the fixture to be initialized and disposed for each test method in a class
    /// You just need to make a new fixture class by Inheriting from TestsBaseFixture (public class MyFixture:TestsBaseFixture)
    /// And use that new fixture class as a base for the test class (public class MyTestsClass:MyFixture)
    /// So the fixture initialize before each test method and then dispose after that test run
    /// ------------------* But *-----------------------------------------------
    /// If you want to share a fixture for all test methods in a Test Class
    /// You just need to Inherit from IClassFixture<TestsBaseFixture> for that test class
    /// And get TestsBaseFixture as a parameter in the constructor
    /// So the TestsBaseFixture initialize before all test methods in that test class and then dispose after all tests run
    /// ------------------* But *-----------------------------------------------
    /// If you want to share a fixture for all test methods in some Test Classes
    /// You just need to make a new class inherited from ICollectionFixture<TestsBaseFixture>
    /// Then apply [CollectionDefinition("my Collection Fixture")] attribute for that new class
    /// And then apply [Collection("my Collection Fixture")] attribute for those test classes you want to share the fixture between them
    /// And get the fixture as a parameter in each test class constructor
    /// So the fixture initialize before all test methods in all test classes and then dispose after all tests run
    /// </summary>
    public abstract class TestsBaseFixture : IDisposable
    {
        #region Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbNameSuffix">To make a unique database for each fixture</param>
        public TestsBaseFixture(string dbNameSuffix)
        {
            _serviceProvider = GetServiceProvider(dbNameSuffix);
            _serviceProvider.InitialDatabase<IdentityDbContext>();
            _serviceProvider.SeedEssentialData();
        }


        #endregion

        #region Protected Methods


        /// <summary>
        /// Get required services for each service
        /// </summary>
        protected T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
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
                                //Copy from Identity.Api project during the build event
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .AddJsonFile("appsettings.Staging.json", optional: true)
                                .AddJsonFile("appsettings.Development.json", optional: true)
                                .AddInMemoryCollection(new[]
                                {
                                   new KeyValuePair<string,string>("ConnectionString:DatabaseName", $"IdentityDB_Test_{dbNameSuffix}")
                                })
                                .Build();

            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            services.AddModules(configuration);

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }



        #endregion

        #region Dispose


        /// <summary>
        /// Dispose all resources that fixture used for tests
        /// </summary>
        public void Dispose()
        {
            _serviceProvider.DropDatabase<IdentityDbContext>();

        }


        #endregion
    }
}
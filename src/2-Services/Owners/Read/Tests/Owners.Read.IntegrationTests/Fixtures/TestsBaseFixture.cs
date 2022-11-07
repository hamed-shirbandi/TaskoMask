using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DI;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures
{
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
            _serviceProvider.InitialDatabase();
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
            _serviceProvider.DropDatabase();

        }


        #endregion
    }
}
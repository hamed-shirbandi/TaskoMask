using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Test
{
    public abstract class IntegrationTestsBase : IDisposable
    {

        protected readonly IServiceProvider _serviceProvider;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbNameSuffix">To make a unique database for each fixture</param>
        public IntegrationTestsBase(string dbNameSuffix)
        {
            _serviceProvider = GetServiceProvider(dbNameSuffix);
            InitialDatabase();
        }



        /// <summary>
        /// 
        /// </summary>
        public abstract void InitialDatabase();



        /// <summary>
        /// 
        /// </summary>
        public abstract void DropDatabase();



        /// <summary>
        /// 
        /// </summary>
        public abstract IServiceProvider GetServiceProvider(string dbNameSuffix);




        /// <summary>
        /// 
        /// </summary>
        protected T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }



        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
           DropDatabase();
        }

    }
}

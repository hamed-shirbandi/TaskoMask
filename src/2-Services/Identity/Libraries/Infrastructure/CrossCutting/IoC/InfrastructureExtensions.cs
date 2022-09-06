using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Identity.Domain.Data;
using TaskoMask.Services.Identity.Infrastructure.Data.DbContext;
using TaskoMask.Services.Identity.Infrastructure.Data.Repositories;

namespace TaskoMask.Services.Identity.Infrastructure.CrossCutting.IoC
{
    public static class InfrastructureExtensions
    {

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }


        #endregion

        #region Private Methods




        /// <summary>
        /// 
        /// </summary>
        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("Mongo");

            services.AddScoped<IIdentityDbContext, IdentityDbContext>().AddOptions<MongoDbOptions>().Bind(options);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }


        #endregion
    }
}

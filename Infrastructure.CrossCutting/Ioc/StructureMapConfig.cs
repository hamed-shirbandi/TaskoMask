using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using TaskoMask.Domain.Data;
using TaskoMask.Infrastructure.Data.DbContext;
using TaskoMask.Infrastructure.Data.Repositories;

namespace Infrastructure.CrossCutting.Ioc
{
   public static class StructureMapConfig
    {
        public static IServiceProvider ConfigureIocContainer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            var container = new Container();
            container.Configure(config =>
            {
                config.For<IMainDbContext>().Use<MainDbContext>();
                config.For<ITaskRepository>().Use<TaskRepository>();
                config.For<IBoardRepository>().Use<BoardRepository>();
                config.For<IOrganizationRepository>().Use<OrganizationRepository>();
                config.For<IProjectRepository>().Use<ProjectRepository>();
                
            });
            

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}

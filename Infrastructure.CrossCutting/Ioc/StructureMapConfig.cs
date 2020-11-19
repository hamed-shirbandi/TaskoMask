using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using TaskoMask.Application.NotificationHandler;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Projects;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Infrastructure.Data.DbContext;
using TaskoMask.Infrastructure.Data.EventSourcing;
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
                config.For<IMainDbContext>().Use<MongoDbContext>();
                config.For<ITaskRepository>().Use<TaskRepository>();
                config.For<IBoardRepository>().Use<BoardRepository>();
                config.For<IOrganizationRepository>().Use<OrganizationRepository>();
                config.For<IProjectRepository>().Use<ProjectRepository>();
                config.For<IEventStore>().Use<RedisEventStore>();
                config.For<IOrganizationService>().Use<OrganizationService>();
                config.For<IProjectService>().Use<ProjectService>();

                services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            });
            

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}

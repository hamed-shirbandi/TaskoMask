using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Application.Services.Boards;
using TaskoMask.Application.Services.Cards;
using TaskoMask.Application.Services.Organizations;
using TaskoMask.Application.Services.Projects;
using TaskoMask.Application.Services.Users;
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
                #region Infrastructure.Date

                //DbContext
                config.For<IMainDbContext>().Use<MongoDbContext>();

                //EventSourcing
                config.For<IEventStore>().Use<RedisEventStore>();

                //Repositories
                config.For<ITaskRepository>().Use<TaskRepository>();
                config.For<IBoardRepository>().Use<BoardRepository>();
                config.For<IOrganizationRepository>().Use<OrganizationRepository>();
                config.For<IProjectRepository>().Use<ProjectRepository>();
                config.For<ICardRepository>().Use<CardRepository>();
                
                #endregion

                #region Application

                //Notification
                services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


                //Sevices
                config.For<IOrganizationService>().Use<OrganizationService>();
                config.For<IProjectService>().Use<ProjectService>();
                config.For<IUserService>().Use<UserService>();
                config.For<IBoardService>().Use<BoardService>();
                config.For<ICardService>().Use<CardService>();
                

                #endregion

            });
            

            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}

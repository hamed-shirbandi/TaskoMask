using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Application.Boards.Services;
using TaskoMask.Application.Cards.Services;
using TaskoMask.Application.Organizations.Services;
using TaskoMask.Application.Projects.Services;
using TaskoMask.Application.Users.Services;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Infrastructure.Data.DbContext;
using TaskoMask.Infrastructure.Data.EventSourcing;
using TaskoMask.Infrastructure.Data.Repositories;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.BaseEntities.Queries.Handlers;
using TaskoMask.Domain.Models;
using TaskoMask.Application.BaseEntities.Queries.Models;
using TaskoMask.Domain.Core.Models;

namespace Infrastructure.CrossCutting.Ioc
{
    public static class StructureMapConfig
    {
        public static IServiceProvider ConfigureIocContainer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton(provider => { return configuration; });

            var container = new Container();
            container.Configure(config =>
            {
                config.For<IEventStore>().Use<RedisEventStore>();
                services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

                #region Generic Query Handlers

                //TODO Handel Generic Command And Queries
                //services.AddScoped(typeof(IRequestHandler<GetEntitiesCountQuery<T>,long>), typeof(BaseEntitiesQueryHandlers<>));
               
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Project>, long>, BaseEntitiesQueryHandlers<Project>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Board>, long>, BaseEntitiesQueryHandlers<Board>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Card>, long>, BaseEntitiesQueryHandlers<Card>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Organization>, long>, BaseEntitiesQueryHandlers<Organization>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Task>, long>, BaseEntitiesQueryHandlers<Task>> ();


                #endregion


                //automatic resolve dependency by default conventions where we have SomeService : ISomeService
                config.Scan(s =>
                {
                    //scan application dll
                    s.AssemblyContainingType<IProjectService>();
                    //scan application.Core dll
                    s.AssemblyContainingType<BaseApplicationService>();
                    //scan Domain dll
                    s.AssemblyContainingType<IProjectRepository>();
                    //Scan Infrastructre.Data dll
                    s.AssemblyContainingType<ProjectRepository>();
                    s.WithDefaultConventions();
                });

            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using TaskoMask.Application.Projects.Services;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Infrastructure.Data.DbContext;
using TaskoMask.Infrastructure.Data.EventSourcing;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.BaseEntities.Queries.Handlers;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.BaseEntities.Queries.Models;
using MediatR.Pipeline;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Infrastructure.CrossCutting.Bus;
using TaskoMask.Domain.Core.Events;

namespace Infrastructure.CrossCutting.Ioc
{

    /// <summary>
    /// 
    /// </summary>
    public static class StructureMapConfig
    {


        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider ConfigureIocContainer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton(provider => { return configuration; });

            var container = new Container();
            container.Configure(config =>
            {
                config.For<IMainDbContext>().Use<MongoDbContext>();
                config.For<IEventStore>().Use<RedisEventStore>();
                services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(ApplicationExceptionsHandler<,,>));

                #region Generic Query Handlers

                //TODO Handel Generic Command And Queries
                //services.AddScoped(typeof(IRequestHandler<GetEntitiesCountQuery<T>,long>), typeof(BaseEntitiesQueryHandlers<>));

                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Project>, long>, BaseEntityQueryHandlers<Project>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Board>, long>, BaseEntityQueryHandlers<Board>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Card>, long>, BaseEntityQueryHandlers<Card>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Organization>, long>, BaseEntityQueryHandlers<Organization>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Task>, long>, BaseEntityQueryHandlers<Task>> ();


                #endregion


                //Automatic resolve dependency by default conventions where we have SomeService : ISomeService
                config.Scan(s =>
                {
                    //scan application dll
                    s.AssemblyContainingType<IProjectService>();
                    //scan application.Core dll
                    s.AssemblyContainingType<IInMemoryBus>();
                    //scan Domain dll
                    s.AssemblyContainingType<IProjectRepository>();
                    //scan Domain.Core dll
                    s.AssemblyContainingType<Event>();
                    //Scan Infrastructre.Data dll
                    s.AssemblyContainingType<IMainDbContext>();
                    //Scan Infrastructure.CrossCutting dll
                    s.AssemblyContainingType<InMemoryBus>();

                    s.WithDefaultConventions();
                });

            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}

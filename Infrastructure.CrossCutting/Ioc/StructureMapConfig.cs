﻿using MediatR;
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
using TaskoMask.Domain.Entities;
using TaskoMask.Application.BaseEntities.Queries.Models;
using TaskoMask.Domain.Core.Models;
using MediatR.Pipeline;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Notifications;

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
                config.For<IMainDbContext>().Use<MongoDbContext>();
                config.For<IEventStore>().Use<RedisEventStore>();
                services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(ApplicationExceptionsHandler<,,>));

                #region Generic Query Handlers

                //TODO Handel Generic Command And Queries
                //services.AddScoped(typeof(IRequestHandler<GetEntitiesCountQuery<T>,long>), typeof(BaseEntitiesQueryHandlers<>));

                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Project>, long>, BaseEntitiesQueryHandlers<Project>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Board>, long>, BaseEntitiesQueryHandlers<Board>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Card>, long>, BaseEntitiesQueryHandlers<Card>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Organization>, long>, BaseEntitiesQueryHandlers<Organization>> ();
                services.AddScoped<IRequestHandler<GetEntitiesCountQuery<Task>, long>, BaseEntitiesQueryHandlers<Task>> ();


                #endregion


                //Automatic resolve dependency by default conventions where we have SomeService : ISomeService
                config.Scan(s =>
                {
                    //scan application dll
                    s.AssemblyContainingType<IProjectService>();
                    //scan application.Core dll
                    s.AssemblyContainingType<IBaseApplicationService>();
                    //scan Domain dll
                    s.AssemblyContainingType<IProjectRepository>();
                    //scan Domain.Core dll
                    s.AssemblyContainingType<IDomainNotificationHandler>();
                    //Scan Infrastructre.Data dll
                    s.AssemblyContainingType<IMainDbContext>();
                    
                    s.WithDefaultConventions();
                });

            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}

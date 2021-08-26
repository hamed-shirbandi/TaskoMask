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
using TaskoMask.Domain.Entities;
using MediatR.Pipeline;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Infrastructure.CrossCutting.Bus;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Users.Queries.Handlers;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Behaviors;
using TaskoMask.Application.Base.Queries.Models;
using TaskoMask.Application.Base.Queries.Handlers;

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
                config.For<IMainDbContext>().Use<MongoDbContext>().ContainerScoped();
                config.For<IEventStore>().Use<RedisEventStore>().ContainerScoped();
                config.For(typeof(IRequestExceptionHandler<,,>)).Use(typeof(ApplicationExceptionsHandler<,,>)).ContainerScoped();
                config.For(typeof(IPipelineBehavior<,>)).Use(typeof(CachingBehavior<,>)).ContainerScoped();
                config.For(typeof(IPipelineBehavior<,>)).Use(typeof(ValidationBehaviour<,>)).ContainerScoped();

                #region Generic Query Handlers

                //TODO Handel Generic Command And Queries
                // config.For(typeof(IRequestHandler<,>)).Use(typeof(BaseQueryHandlers<>)).ContainerScoped();

                services.AddScoped<IRequestHandler<GetCountQuery<Operator>, long>, BaseQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Manager>, long>, BaseQueryHandlers<Manager>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Organization>, long>, BaseQueryHandlers<Organization>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Project>, long>, BaseQueryHandlers<Project>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Board>, long>, BaseQueryHandlers<Board>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Task>, long>, BaseQueryHandlers<Task>>();
                services.AddScoped<IRequestHandler<GetCountQuery<Card>, long>, BaseQueryHandlers<Card>>();


                services.AddScoped<IRequestHandler<GetUserByIdQuery<Operator>, UserBasicInfoDto>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetUserByIdQuery<Manager>, UserBasicInfoDto>, UserQueryHandlers<Manager>>();

                services.AddScoped<IRequestHandler<GetUserByPhoneNumberQuery<Operator>, UserBasicInfoDto>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetUserByPhoneNumberQuery<Manager>, UserBasicInfoDto>, UserQueryHandlers<Manager>>();

                services.AddScoped<IRequestHandler<GetUserByUserNameQuery<Operator>, UserBasicInfoDto>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<GetUserByUserNameQuery<Manager>, UserBasicInfoDto>, UserQueryHandlers<Manager>>();

                services.AddScoped<IRequestHandler<ValidateUserPasswordQuery<Operator>, bool>, UserQueryHandlers<Operator>>();
                services.AddScoped<IRequestHandler<ValidateUserPasswordQuery<Manager>, bool>, UserQueryHandlers<Manager>>();


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

                    s.WithDefaultConventions().OnAddedPluginTypes(c => c.ContainerScoped());
                });

            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}

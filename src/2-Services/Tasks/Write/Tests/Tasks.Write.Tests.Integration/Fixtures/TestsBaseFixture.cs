using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Tasks.Write.Domain.Data;
using TaskoMask.Services.Tasks.Write.Domain.Entities;
using TaskoMask.Services.Tasks.Write.Domain.Services;
using TaskoMask.Services.Tasks.Write.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Tasks.Write.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures
{
    public abstract class TestsBaseFixture : IntegrationTestsBase
    {
        public readonly ITaskAggregateRepository TaskAggregateRepository;
        public readonly ITaskValidatorService TaskValidatorService;
        public readonly IMessageBus MessageBus;
        public readonly IInMemoryBus InMemoryBus;


        protected TestsBaseFixture(string dbNameSuffix) : base(dbNameSuffix)
        {
            TaskAggregateRepository = GetRequiredService<ITaskAggregateRepository>();
            TaskValidatorService = GetRequiredService<ITaskValidatorService>();
            MessageBus = Substitute.For<IMessageBus>();
            InMemoryBus = Substitute.For<IInMemoryBus>();
        }


        /// <summary>
        /// 
        /// </summary>
        public override void InitialDatabase()
        {
            _serviceProvider.InitialDatabasesAndSeedEssentialData();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void DropDatabase()
        {
            _serviceProvider.DropDatabase();
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task SeedTaskAsync(Task task)
        {
            await TaskAggregateRepository.AddAsync(task);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task<Task> GetTaskAsync(string id)
        {
            return await TaskAggregateRepository.GetByIdAsync(id);
        }



        /// <summary>
        /// 
        /// </summary>
        public override IServiceProvider GetServiceProvider(string dbNameSuffix)
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                                //Copy from Tasks.Write.Api comment during the build event
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .AddJsonFile("appsettings.Staging.json", optional: true)
                                .AddJsonFile("appsettings.Development.json", optional: true)
                                .AddInMemoryCollection(new[]
                                {
                                   new KeyValuePair<string,string>("MongoDB:DatabaseName", $"Tasks_Write_DB_{dbNameSuffix}")
                                })
                                .Build();

            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            services.AddModules(configuration, typeof(TestsBaseFixture));

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
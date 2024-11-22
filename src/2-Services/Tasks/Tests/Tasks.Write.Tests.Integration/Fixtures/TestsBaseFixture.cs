using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Data;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;
using TaskoMask.Services.Tasks.Write.Api.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;

public abstract class TestsBaseFixture : IntegrationTestsBase
{
    public readonly ITaskAggregateRepository _taskAggregateRepository;
    public readonly ITaskValidatorService _taskValidatorService;
    public readonly IEventPublisher _eventPublisher;
    public readonly IRequestDispatcher _requestDispatcher;

    protected TestsBaseFixture(string dbNameSuffix)
        : base(dbNameSuffix)
    {
        _taskAggregateRepository = GetRequiredService<ITaskAggregateRepository>();
        _taskValidatorService = GetRequiredService<ITaskValidatorService>();
        _eventPublisher = Substitute.For<IEventPublisher>();
        _requestDispatcher = Substitute.For<IRequestDispatcher>();
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
        await _taskAggregateRepository.AddAsync(task);
    }

    /// <summary>
    ///
    /// </summary>
    public async System.Threading.Tasks.Task<Task> GetTaskAsync(string id)
    {
        return await _taskAggregateRepository.GetByIdAsync(id);
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
            .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("MongoDB:DatabaseName", $"Tasks_Write_DB_{dbNameSuffix}") })
            .Build();

        services.AddSingleton<IConfiguration>(provider =>
        {
            return configuration;
        });

        services.AddModules(configuration);

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}

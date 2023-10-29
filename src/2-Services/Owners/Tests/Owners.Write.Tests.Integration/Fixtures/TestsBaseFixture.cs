using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Services;
using TaskoMask.Services.Owners.Write.Api.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Owners.Write.Api.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;

public abstract class TestsBaseFixture : IntegrationTestsBase
{
    public readonly IOwnerAggregateRepository _ownerAggregateRepository;
    public readonly IOwnerValidatorService _ownerValidatorService;
    public readonly IMessageBus _messageBus;
    public readonly IInMemoryBus _inMemoryBus;

    protected TestsBaseFixture(string dbNameSuffix)
        : base(dbNameSuffix)
    {
        _ownerAggregateRepository = GetRequiredService<IOwnerAggregateRepository>();
        _ownerValidatorService = GetRequiredService<IOwnerValidatorService>();
        _messageBus = Substitute.For<IMessageBus>();
        _inMemoryBus = Substitute.For<IInMemoryBus>();
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
    public async Task SeedOwnerAsync(Owner owner)
    {
        await _ownerAggregateRepository.AddAsync(owner);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Owner> GetOwnerAsync(string id)
    {
        return await _ownerAggregateRepository.GetByIdAsync(id);
    }

    /// <summary>
    ///
    /// </summary>
    public override IServiceProvider GetServiceProvider(string dbNameSuffix)
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            //Copy from Owners.Write.Api project during the build event
            .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
            .AddJsonFile("appsettings.Staging.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("MongoDB:DatabaseName", $"Owners_Write_DB_{dbNameSuffix}") })
            .Build();

        services.AddSingleton<IConfiguration>(provider =>
        {
            return configuration;
        });

        services.AddModules(configuration, typeof(TestsBaseFixture));

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}

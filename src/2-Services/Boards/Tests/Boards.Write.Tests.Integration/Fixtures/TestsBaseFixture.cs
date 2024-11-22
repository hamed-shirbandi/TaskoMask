using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Data;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Services;
using TaskoMask.Services.Boards.Write.Api.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Boards.Write.Api.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;

public abstract class TestsBaseFixture : IntegrationTestsBase
{
    public readonly IBoardAggregateRepository _boardAggregateRepository;
    public readonly IBoardValidatorService _boardValidatorService;
    public readonly IEventPublisher _eventPublisher;
    public readonly IRequestDispatcher _requestDispatcher;

    protected TestsBaseFixture(string dbNameSuffix)
        : base(dbNameSuffix)
    {
        _boardAggregateRepository = GetRequiredService<IBoardAggregateRepository>();
        _boardValidatorService = GetRequiredService<IBoardValidatorService>();
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
    public async Task SeedBoardAsync(Board board)
    {
        await _boardAggregateRepository.AddAsync(board);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Board> GetBoardAsync(string id)
    {
        return await _boardAggregateRepository.GetByIdAsync(id);
    }

    /// <summary>
    ///
    /// </summary>
    public override IServiceProvider GetServiceProvider(string dbNameSuffix)
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            //Copy from Boards.Write.Api card during the build event
            .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
            .AddJsonFile("appsettings.Staging.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("MongoDB:DatabaseName", $"Boards_Write_DB_{dbNameSuffix}") })
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

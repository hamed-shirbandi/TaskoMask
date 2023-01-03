using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Boards.Write.Domain.Data;
using TaskoMask.Services.Boards.Write.Domain.Entities;
using TaskoMask.Services.Boards.Write.Domain.Services;
using TaskoMask.Services.Boards.Write.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Boards.Write.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures
{
    public abstract class TestsBaseFixture : IntegrationTestsBase
    {
        public readonly IBoardAggregateRepository BoardAggregateRepository;
        public readonly IBoardValidatorService BoardValidatorService;
        public readonly IMessageBus MessageBus;
        public readonly IInMemoryBus InMemoryBus;


        protected TestsBaseFixture(string dbNameSuffix) : base(dbNameSuffix)
        {
            BoardAggregateRepository = GetRequiredService<IBoardAggregateRepository>();
            BoardValidatorService = GetRequiredService<IBoardValidatorService>();
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
        public async Task SeedBoardAsync(Board board)
        {
            await BoardAggregateRepository.AddAsync(board);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Board> GetBoardAsync(string id)
        {
            return await BoardAggregateRepository.GetByIdAsync(id);
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
                                .AddInMemoryCollection(new[]
                                {
                                   new KeyValuePair<string,string>("MongoDB:DatabaseName", $"Boards_Write_DB_{dbNameSuffix}")
                                })
                                .Build();

            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            services.AddModules(configuration, typeof(TestsBaseFixture));

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
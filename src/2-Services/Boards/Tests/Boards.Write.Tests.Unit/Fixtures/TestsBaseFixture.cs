using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Data;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Services;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;

namespace TaskoMask.Services.Boards.Write.Tests.Unit.Fixtures;

public abstract class TestsBaseFixture : UnitTestsBase
{
    protected IEventPublisher MessageBus;
    protected IRequestDispatcher InMemoryBus;
    protected IBoardAggregateRepository BoardAggregateRepository;
    protected IBoardValidatorService BoardValidatorService;
    protected List<Board> Boards;

    ///// <summary>
    /////
    ///// </summary>
    protected override void FixtureSetup()
    {
        CommonFixtureSetup();

        TestClassFixtureSetup();
    }

    /// <summary>
    ///
    /// </summary>
    private void CommonFixtureSetup()
    {
        MessageBus = Substitute.For<IEventPublisher>();

        InMemoryBus = Substitute.For<IRequestDispatcher>();

        Boards = GenerateBoardsList();

        BoardValidatorService = Substitute.For<IBoardValidatorService>();
        BoardValidatorService
            .BoardHasUniqueName(boardId: Arg.Any<string>(), projectId: Arg.Any<string>(), boardName: Arg.Any<string>())
            .Returns(args =>
            {
                return !Boards.Any(o => o.ProjectId.Value == (string)args[1] && o.Id != (string)args[0] && o.Name.Value == (string)args[2]);
            });

        BoardAggregateRepository = Substitute.For<IBoardAggregateRepository>();
        BoardAggregateRepository
            .GetByIdAsync(Arg.Is<string>(x => Boards.Any(o => o.Id == x)))
            .Returns(args => Boards.First(u => u.Id == (string)args[0]));
        BoardAggregateRepository
            .AddAsync(Arg.Any<Board>())
            .Returns(args =>
            {
                Boards.Add((Board)args[0]);
                return Task.CompletedTask;
            });
        BoardAggregateRepository
            .UpdateAsync(Arg.Is<Board>(x => Boards.Any(o => o.Id == x.Id)))
            .Returns(args =>
            {
                var existBoard = Boards.FirstOrDefault(u => u.Id == ((Board)args[0]).Id);
                if (existBoard != null)
                {
                    Boards.Remove(existBoard);
                    Boards.Add((Board)args[0]);
                }

                return Task.CompletedTask;
            });
        BoardAggregateRepository
            .ConcurrencySafeUpdate(Arg.Is<Board>(x => Boards.Any(o => o.Id == x.Id)), Arg.Is<string>(x => x.Any()))
            .Returns(args =>
            {
                var existBoard = Boards.FirstOrDefault(u => u.Id == ((Board)args[0]).Id && u.Version == (string)args[1]);
                if (existBoard != null)
                {
                    Boards.Remove(existBoard);
                    Boards.Add((Board)args[0]);
                }

                return Task.CompletedTask;
            });
        BoardAggregateRepository
            .DeleteAsync(Arg.Is<string>(x => Boards.Any(o => o.Id == x)))
            .Returns(args =>
            {
                var board = Boards.FirstOrDefault(u => u.Id == (string)args[0]);
                if (board != null)
                    Boards.Remove(board);

                return Task.CompletedTask;
            });
        BoardAggregateRepository
            .GetByCardIdAsync(Arg.Is<string>(x => x.Any()))
            .Returns(args =>
            {
                return Boards.FirstOrDefault(u => u.Cards.Any(c => c.Id == (string)args[0]));
            });
    }

    /// <summary>
    /// Each test class should setup its own fixture
    /// </summary>
    protected abstract void TestClassFixtureSetup();

    /// <summary>
    ///
    /// </summary>
    private List<Board> GenerateBoardsList()
    {
        var boardValidatorService = Substitute.For<IBoardValidatorService>();
        boardValidatorService
            .BoardHasUniqueName(boardId: Arg.Any<string>(), projectId: Arg.Any<string>(), boardName: Arg.Any<string>())
            .Returns(true);
        return BoardObjectMother.GenerateBoardsList(boardValidatorService);
    }
}

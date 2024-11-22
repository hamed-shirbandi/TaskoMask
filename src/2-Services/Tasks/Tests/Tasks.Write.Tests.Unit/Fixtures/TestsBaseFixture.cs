using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Data;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;

public abstract class TestsBaseFixture : UnitTestsBase
{
    protected IEventPublisher MessageBus;
    protected IRequestDispatcher InMemoryBus;
    protected ITaskAggregateRepository TaskAggregateRepository;
    protected ITaskValidatorService TaskValidatorService;
    protected List<Api.Domain.Tasks.Entities.Task> Tasks;

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

        Tasks = GenerateTasksList();

        TaskValidatorService = Substitute.For<ITaskValidatorService>();
        TaskValidatorService
            .TaskHasUniqueName(taskId: Arg.Any<string>(), boardId: Arg.Any<string>(), taskTitle: Arg.Any<string>())
            .Returns(args =>
            {
                return !Tasks.Any(o => o.BoardId.Value == (string)args[1] && o.Id != (string)args[0] && o.Title.Value == (string)args[2]);
            });
        TaskValidatorService
            .CanAddNewTaskToBoard(boardId: Arg.Any<string>(), maxTasksCount: Arg.Any<int>())
            .Returns(args =>
            {
                var tasksCount = Tasks.Count(t => t.BoardId.Value == (string)args[0]);
                return tasksCount < (int)args[1];
            });

        TaskAggregateRepository = Substitute.For<ITaskAggregateRepository>();
        TaskAggregateRepository
            .GetByIdAsync(Arg.Is<string>(x => Tasks.Any(o => o.Id == x)))
            .Returns(args => Tasks.First(u => u.Id == (string)args[0]));
        TaskAggregateRepository
            .AddAsync(Arg.Any<Api.Domain.Tasks.Entities.Task>())
            .Returns(args =>
            {
                Tasks.Add((Api.Domain.Tasks.Entities.Task)args[0]);
                return Task.CompletedTask;
            });
        TaskAggregateRepository
            .UpdateAsync(Arg.Is<Api.Domain.Tasks.Entities.Task>(x => Tasks.Any(o => o.Id == x.Id)))
            .Returns(args =>
            {
                var existTask = Tasks.FirstOrDefault(u => u.Id == ((Api.Domain.Tasks.Entities.Task)args[0]).Id);
                if (existTask != null)
                {
                    Tasks.Remove(existTask);
                    Tasks.Add((Api.Domain.Tasks.Entities.Task)args[0]);
                }

                return Task.CompletedTask;
            });
        TaskAggregateRepository
            .ConcurrencySafeUpdate(Arg.Is<Api.Domain.Tasks.Entities.Task>(x => Tasks.Any(o => o.Id == x.Id)), Arg.Is<string>(x => x.Any()))
            .Returns(args =>
            {
                var existTask = Tasks.FirstOrDefault(u => u.Id == ((Api.Domain.Tasks.Entities.Task)args[0]).Id && u.Version == (string)args[1]);
                if (existTask != null)
                {
                    Tasks.Remove(existTask);
                    Tasks.Add((Api.Domain.Tasks.Entities.Task)args[0]);
                }

                return Task.CompletedTask;
            });
        TaskAggregateRepository
            .DeleteAsync(Arg.Is<string>(x => Tasks.Any(o => o.Id == x)))
            .Returns(args =>
            {
                var task = Tasks.FirstOrDefault(u => u.Id == (string)args[0]);
                if (task != null)
                    Tasks.Remove(task);

                return Task.CompletedTask;
            });
        TaskAggregateRepository
            .GetByCommentIdAsync(Arg.Is<string>(x => x.Any()))
            .Returns(args =>
            {
                return Tasks.FirstOrDefault(u => u.Comments.Any(c => c.Id == (string)args[0]));
            });
    }

    /// <summary>
    /// Each test class should setup its own fixture
    /// </summary>
    protected abstract void TestClassFixtureSetup();

    /// <summary>
    ///
    /// </summary>
    private List<Api.Domain.Tasks.Entities.Task> GenerateTasksList()
    {
        var taskValidatorService = Substitute.For<ITaskValidatorService>();
        taskValidatorService.TaskHasUniqueName(taskId: Arg.Any<string>(), boardId: Arg.Any<string>(), taskTitle: Arg.Any<string>()).Returns(true);
        taskValidatorService.CanAddNewTaskToBoard(boardId: Arg.Any<string>(), maxTasksCount: Arg.Any<int>()).Returns(true);
        return TaskObjectMother.GenerateTasksList(taskValidatorService);
    }
}

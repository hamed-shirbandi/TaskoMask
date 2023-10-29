using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.DeleteTask;
using TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.UseCases.Tasks;

public class DeleteTaskTests : TestsBaseFixture
{
    #region Fields

    private DeleteTaskUseCase deleteTaskUseCase;

    #endregion

    #region Ctor

    public DeleteTaskTests() { }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Task_is_deleted()
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var deleteTaskRequest = new DeleteTaskRequest(expectedTask.Id);

        //Act
        var result = await deleteTaskUseCase.Handle(deleteTaskRequest, CancellationToken.None);

        //Assert
        result.EntityId.Should().NotBeNull();
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var deleteedTask = Tasks.FirstOrDefault(u => u.Id == result.EntityId);
        deleteedTask.Should().BeNull();

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<TaskDeletedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<TaskDeleted>());
    }

    [Fact]
    public async Task Deleting_a_task_will_throw_an_exception_if_Id_is_not_existed()
    {
        //Arrange
        var notExistedTaskId = ObjectId.GenerateNewId().ToString();
        var deleteTaskRequest = new DeleteTaskRequest(notExistedTaskId);
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

        //Act
        Func<Task> act = async () => await deleteTaskUseCase.Handle(deleteTaskRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        deleteTaskUseCase = new DeleteTaskUseCase(TaskAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}

using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.UpdateTask;
using TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.UseCases.Tasks;

public class UpdateTaskTests : TestsBaseFixture
{
    #region Fields

    private UpdateTaskUseCase updateTaskUseCase;

    #endregion

    #region Ctor

    public UpdateTaskTests() { }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Task_is_updated()
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var updateTaskRequest = new UpdateTaskRequest(expectedTask.Id, "Test_New_Title", "Test_New_Description");

        //Act
        var result = await updateTaskUseCase.Handle(updateTaskRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Update_Success);
        result.EntityId.Should().Be(expectedTask.Id);

        expectedTask.Title.Value.Should().Be(updateTaskRequest.Title);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<TaskUpdatedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<TaskUpdated>());
    }

    [Fact]
    public async Task Updatting_a_task_will_throw_an_exception_if_Id_is_not_existed()
    {
        //Arrange
        var notExistedTaskId = ObjectId.GenerateNewId().ToString();
        var updateTaskRequest = new UpdateTaskRequest(notExistedTaskId, "Test_New_Title", "Test_New_Description");
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

        //Act
        Func<Task> act = async () => await updateTaskUseCase.Handle(updateTaskRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [Fact]
    public async Task Updating_a_task_will_change_its_version()
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var previousVersion = expectedTask.Version;
        var updateTaskRequest = new UpdateTaskRequest(expectedTask.Id, "Test_New_Title", "Test_New_Description");

        //Act
        await updateTaskUseCase.Handle(updateTaskRequest, CancellationToken.None);

        //Assert
        expectedTask.Version.Should().NotBeNullOrEmpty().And.NotBe(previousVersion);
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        updateTaskUseCase = new UpdateTaskUseCase(TaskAggregateRepository, MessageBus, InMemoryBus, TaskValidatorService);
    }

    #endregion
}

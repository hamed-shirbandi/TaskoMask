using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.ValueObjects.Tasks;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.AddTask;
using TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.UseCases.Tasks;

public class AddTaskTests : TestsBaseFixture
{
    #region Fields

    private AddTaskUseCase addTaskUseCase;

    #endregion

    #region Ctor

    public AddTaskTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Task_is_added()
    {
        //Arrange
        var addTaskRequest = new AddTaskRequest(
            cardId: ObjectId.GenerateNewId().ToString(),
            boardId: ObjectId.GenerateNewId().ToString(),
            "Test_Title",
            "Test_Description"
        );

        //Act
        var result = await addTaskUseCase.Handle(addTaskRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Create_Success);
        result.EntityId.Should().NotBeNull();

        var addedTask = Tasks.FirstOrDefault(u => u.Id == result.EntityId);
        addedTask.Should().NotBeNull();
        addedTask.Title.Value.Should().Be(addTaskRequest.Title);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<TaskAddedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<TaskAdded>());
    }

    [InlineData("test", "test")]
    [InlineData("تست", "تست")]
    [Theory]
    public async Task Task_is_not_added_if_title_and_description_are_the_same(string name, string description)
    {
        //Arrange
        var addTaskRequest = new AddTaskRequest(
            cardId: ObjectId.GenerateNewId().ToString(),
            boardId: ObjectId.GenerateNewId().ToString(),
            name,
            description
        );
        var expectedMessage = DomainMessages.Equal_Name_And_Description_Error;

        //Act
        Func<Task> act = async () => await addTaskUseCase.Handle(addTaskRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [InlineData("Th")]
    [InlineData("This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test")]
    [Theory]
    public async Task Task_is_not_added_if_title_lenght_is_less_than_min_or_more_than_max(string name)
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var addTaskRequest = new AddTaskRequest(
            cardId: ObjectId.GenerateNewId().ToString(),
            boardId: ObjectId.GenerateNewId().ToString(),
            name,
            "Test_Description"
        );
        var expectedMessage = string.Format(
            ContractsMetadata.Length_Error,
            nameof(TaskTitle),
            DomainConstValues.TASK_TITLE_MIN_LENGTH,
            DomainConstValues.TASK_TITLE_MAX_LENGTH
        );

        //Act
        Func<Task> act = async () => await addTaskUseCase.Handle(addTaskRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [Fact]
    public async Task Task_is_not_added_if_title_is_not_unique_in_a_board()
    {
        //Arrange
        var expectedMessage = string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Task);
        var existedTask = Tasks.FirstOrDefault();
        var addTaskRequest = new AddTaskRequest(existedTask.CardId.Value, existedTask.BoardId.Value, existedTask.Title.Value, "Test_Description");

        //Act
        Func<Task> act = async () => await addTaskUseCase.Handle(addTaskRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        addTaskUseCase = new AddTaskUseCase(TaskAggregateRepository, MessageBus, InMemoryBus, TaskValidatorService);
    }

    #endregion
}

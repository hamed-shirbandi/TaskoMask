using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.MoveTaskToAnotherCard;
using TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.UseCases.Tasks;

public class MoveTaskToAnotherCardTests : TestsBaseFixture
{
    #region Fields

    private MoveTaskToAnotherCardUseCase moveTaskToAnotherCardUseCase;

    #endregion

    #region Ctor

    public MoveTaskToAnotherCardTests() { }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Task_is_moved_to_another_card()
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var expectedCardId = ObjectId.GenerateNewId().ToString();
        var moveTaskToAnotherCardRequest = new MoveTaskToAnotherCardRequest(expectedTask.Id, expectedCardId);

        //Act
        var result = await moveTaskToAnotherCardUseCase.Handle(moveTaskToAnotherCardRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Update_Success);
        result.EntityId.Should().Be(expectedTask.Id);

        expectedTask.CardId.Value.Should().Be(expectedCardId);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<TaskMovedToAnotherCardEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<TaskMovedToAnotherCard>());
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        moveTaskToAnotherCardUseCase = new MoveTaskToAnotherCardUseCase(TaskAggregateRepository, MessageBus, InMemoryBus, TaskValidatorService);
    }

    #endregion
}

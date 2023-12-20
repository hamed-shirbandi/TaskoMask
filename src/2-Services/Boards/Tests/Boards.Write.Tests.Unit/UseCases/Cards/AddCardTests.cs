using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Cards;
using TaskoMask.Services.Boards.Write.Api.UseCases.Cards.AddCard;
using TaskoMask.Services.Boards.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Unit.UseCases.Cards;

public class AddCardTests : TestsBaseFixture
{
    #region Fields

    private AddCardUseCase addCardUseCase;

    #endregion

    #region Ctor

    public AddCardTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Card_is_added()
    {
        //Arrange
        var expectedBoard = Boards.FirstOrDefault();
        var addCardRequest = new AddCardRequest(expectedBoard.Id, "Test_Name", BoardCardType.ToDo);

        //Act
        var result = await addCardUseCase.Handle(addCardRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Create_Success);
        result.EntityId.Should().NotBeNull();

        var addedCard = expectedBoard.GetCardById(result.EntityId);
        addedCard.Should().NotBeNull();
        addedCard.Name.Value.Should().Be(addCardRequest.Name);
        addedCard.Type.Value.Should().Be(addCardRequest.Type);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<CardAddedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<CardAdded>());
    }

    [Fact]
    public async Task Adding_a_card_will_throw_an_exception_if_board_Id_is_not_existed()
    {
        //Arrange
        var notExistedBoardId = ObjectId.GenerateNewId().ToString();
        var addCardRequest = new AddCardRequest(notExistedBoardId, "Test_Name", BoardCardType.ToDo);
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

        //Act
        Func<Task> act = async () => await addCardUseCase.Handle(addCardRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        addCardUseCase = new AddCardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}

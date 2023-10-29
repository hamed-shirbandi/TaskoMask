using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Cards;
using TaskoMask.Services.Boards.Write.Api.UseCases.Cards.DeleteCard;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using TaskoMask.Services.Boards.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Unit.UseCases.Cards;

public class DeleteCardTests : TestsBaseFixture
{
    #region Fields

    private DeleteCardUseCase deleteCardUseCase;

    #endregion

    #region Ctor

    public DeleteCardTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Card_is_deleted()
    {
        //Arrange
        var expectedBoard = Boards.FirstOrDefault();
        var expectedCard = BoardObjectMother.CreateCard();
        expectedBoard.AddCard(expectedCard);
        var deleteCardRequest = new DeleteCardRequest(expectedCard.Id);
        var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Card);

        //Act
        var result = await deleteCardUseCase.Handle(deleteCardRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Update_Success);
        result.EntityId.Should().Be(expectedCard.Id);

        //Act
        Action act = () => expectedBoard.GetCardById(expectedCard.Id);

        //Assert
        act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<CardDeletedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<CardDeleted>());
    }

    [Fact]
    public async Task Deleting_a_card_will_throw_an_exception_if_Id_is_not_existed()
    {
        //Arrange
        var notExistedCardId = ObjectId.GenerateNewId().ToString();
        var deleteCardRequest = new DeleteCardRequest(notExistedCardId);
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Card);

        //Act
        Func<Task> act = async () => await deleteCardUseCase.Handle(deleteCardRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        deleteCardUseCase = new DeleteCardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}

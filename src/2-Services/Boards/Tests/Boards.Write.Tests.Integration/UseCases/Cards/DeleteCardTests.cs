using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Api.UseCases.Cards.DeleteCard;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Cards;

[Collection(nameof(CardCollectionFixture))]
public class DeleteCardTests
{
    #region Fields

    private readonly CardCollectionFixture _fixture;

    #endregion

    #region Ctor

    public DeleteCardTests(CardCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Card_is_deleted()
    {
        //Arrange
        var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Card);
        var expectedBoard = BoardObjectMother.CreateBoardWithOneCard(_fixture._boardValidatorService);
        await _fixture.SeedBoardAsync(expectedBoard);

        var expectedCard = expectedBoard.Cards.FirstOrDefault();

        var request = new DeleteCardRequest(expectedCard.Id);
        var deleteCardUseCase = new DeleteCardUseCase(_fixture._boardAggregateRepository, _fixture._eventPublisher, _fixture._requestDispatcher);

        //Act
        var result = await deleteCardUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedCard.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedBoard = await _fixture.GetBoardAsync(expectedBoard.Id);
        Action act = () => updatedBoard.GetCardById(expectedCard.Id);
        act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion
}

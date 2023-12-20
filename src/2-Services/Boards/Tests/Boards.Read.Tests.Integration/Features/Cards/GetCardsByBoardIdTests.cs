using FluentAssertions;
using TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;
using TaskoMask.Services.Boards.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Boards.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Read.Tests.Integration.Features.Cards;

[Collection(nameof(CardCollectionFixture))]
public class GetCardsByBoardIdTests
{
    #region Fields

    private readonly CardCollectionFixture _fixture;

    #endregion

    #region Ctor

    public GetCardsByBoardIdTests(CardCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Cards_are_fetched_by_board_Id()
    {
        //Arrange
        var expectedCard = CardObjectMother.CreateCard();
        await _fixture.SeedCardAsync(expectedCard);
        var getCardsByBoardIdHandler = new GetCardsByBoardIdHandler(_fixture._dbContext, _fixture._mapper);
        var request = new GetCardsByBoardIdRequest(expectedCard.BoardId);

        //Act
        var result = await getCardsByBoardIdHandler.Handle(request, CancellationToken.None);

        //Assert
        result.Should().HaveCountGreaterThanOrEqualTo(1);
        result.Should().Contain(c => c.Id == expectedCard.Id);
    }

    #endregion
}

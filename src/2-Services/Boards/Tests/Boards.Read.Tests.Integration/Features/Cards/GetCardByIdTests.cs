using FluentAssertions;
using TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById;
using TaskoMask.Services.Boards.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Boards.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Read.Tests.Integration.Features.Cards;

[Collection(nameof(CardCollectionFixture))]
public class GetCardByIdTests
{
    #region Fields

    private readonly CardCollectionFixture _fixture;

    #endregion

    #region Ctor

    public GetCardByIdTests(CardCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Card_is_fetched_by_Id()
    {
        //Arrange
        var expectedCard = CardObjectMother.CreateCard();
        await _fixture.SeedCardAsync(expectedCard);
        var getCardByIdHandler = new GetCardByIdHandler(_fixture._dbContext, _fixture._mapper);
        var request = new GetCardByIdRequest(expectedCard.Id);

        //Act
        var result = await getCardByIdHandler.Handle(request, CancellationToken.None);

        //Assert
        result.Id.Should().Be(expectedCard.Id);
        result.Name.Should().Be(expectedCard.Name);
    }

    #endregion
}

using FluentAssertions;
using TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;
using TaskoMask.Services.Boards.Read.IntegrationTests.Fixtures;
using TaskoMask.Services.Boards.Read.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Read.IntegrationTests.Features.Card
{
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
        public async Task Cards_Are_Fetched_By_BoardId()
        {
            //Arrange
            var expectedCard = CardObjectMother.GetCard();
            await _fixture.SeedCardAsync(expectedCard);
            var getCardsByBoardIdHandler = new GetCardsByBoardIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetCardsByBoardIdRequest(expectedCard.BoardId);

            //Act
            var result = await getCardsByBoardIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCount(1);
            result.FirstOrDefault().Name.Should().Be(expectedCard.Name);
        }


        #endregion
    }
}

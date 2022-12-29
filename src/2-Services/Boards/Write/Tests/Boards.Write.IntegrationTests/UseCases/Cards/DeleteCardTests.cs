using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.DeleteCard;
using TaskoMask.Services.Boards.Write.IntegrationTests.Fixtures;
using TaskoMask.Services.Boards.Write.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Write.IntegrationTests.UseCases.Cards
{
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
        public async Task Card_Is_Deleted()
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Card);
            var expectedBoard = BoardObjectMother.GetABoardWithACard(_fixture.BoardValidatorService);
            await _fixture.SeedBoardAsync(expectedBoard);

            var expectedCard = expectedBoard.Cards.FirstOrDefault();

            var request = new DeleteCardRequest(expectedCard.Id);
            var deleteCardUseCase = new DeleteCardUseCase(_fixture.BoardAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await deleteCardUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedCard.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var updatedBoard = await _fixture.GetBoardAsync(expectedBoard.Id);
            var deletedCard = updatedBoard.Cards.FirstOrDefault(c => c.Id == result.EntityId);
            deletedCard.Should().BeNull();
        }


        #endregion
    }
}

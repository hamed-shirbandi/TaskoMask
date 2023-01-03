using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.UpdateCard;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Cards
{
    [Collection(nameof(CardCollectionFixture))]
    public class UpdateCardTests
    {

        #region Fields

        private readonly CardCollectionFixture _fixture;

        #endregion

        #region Ctor

        public UpdateCardTests(CardCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Card_is_updated()
        {
            //Arrange
            var expectedBoard = BoardObjectMother.CreateBoardWithOneCard(_fixture.BoardValidatorService);
            var expectedCard = expectedBoard.Cards.FirstOrDefault();
            await _fixture.SeedBoardAsync(expectedBoard);

            var request = new UpdateCardRequest(id: expectedCard.Id, name: "Test New Name", type: BoardCardType.Doing);
            var updateCardUseCase = new UpdateCardUseCase(_fixture.BoardAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await updateCardUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedCard.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var updatedBoard = await _fixture.GetBoardAsync(expectedBoard.Id);
            var updatedCard = updatedBoard.GetCardById(expectedCard.Id);

            updatedCard.Name.Value.Should().Be(request.Name);
            updatedCard.Type.Value.Should().Be(request.Type);
        }


        #endregion
    }
}

using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.DeleteCard;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Cards
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
        public async Task Card_is_deleted()
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Card);
            var expectedBoard = BoardObjectMother.CreateBoardWithOneCard(_fixture.BoardValidatorService);
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
            Action act = () => updatedBoard.GetCardById(expectedCard.Id);
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }


        #endregion
    }
}

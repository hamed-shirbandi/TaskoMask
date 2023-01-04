using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.DeleteBoard;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Boards
{
    [Collection(nameof(BoardCollectionFixture))]
    public class DeleteBoardTests
    {

        #region Fields

        private readonly BoardCollectionFixture _fixture;

        #endregion

        #region Ctor

        public DeleteBoardTests(BoardCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Board_is_deleted()
        {
            //Arrange
            var expectedBoard = BoardObjectMother.CreateBoard(_fixture.BoardValidatorService);
            await _fixture.SeedBoardAsync(expectedBoard);

            var request = new DeleteBoardRequest(expectedBoard.Id);
            var deleteBoardUseCase = new DeleteBoardUseCase(_fixture.BoardAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await deleteBoardUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedBoard.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var deletedBoard = await _fixture.GetBoardAsync(expectedBoard.Id);
            deletedBoard.Should().BeNull();
        }


        #endregion
    }
}

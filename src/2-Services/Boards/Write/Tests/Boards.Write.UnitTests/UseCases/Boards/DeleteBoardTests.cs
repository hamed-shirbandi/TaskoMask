using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.DeleteBoard;
using TaskoMask.Services.Boards.Write.Domain.Events.Boards;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Boards
{
    public class DeleteBoardTests : TestsBaseFixture
    {

        #region Fields

        private DeleteBoardUseCase _deleteBoardUseCase;

        #endregion

        #region Ctor

        public DeleteBoardTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Board_Is_Deleted()
        {
            //Arrange
            var expectedBoard = Boards.FirstOrDefault();
            var deleteBoardRequest = new DeleteBoardRequest(expectedBoard.Id);

            //Act
            var result = await _deleteBoardUseCase.Handle(deleteBoardRequest, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNull();
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var deleteedBoard = Boards.FirstOrDefault(u => u.Id == result.EntityId);
            deleteedBoard.Should().BeNull();

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<BoardDeletedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<BoardDeleted>());
        }



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _deleteBoardUseCase = new DeleteBoardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}

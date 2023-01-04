using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.DeleteBoard;
using TaskoMask.Services.Boards.Write.Domain.Events.Boards;
using TaskoMask.Services.Boards.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Unit.UseCases.Boards
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
        public async Task Board_is_deleted()
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



        [Fact]
        public async Task Deleting_a_board_will_throw_an_exception_if_Id_is_not_existed()
        {
            //Arrange
            var notExistedBoardId = ObjectId.GenerateNewId().ToString();
            var deleteBoardRequest = new DeleteBoardRequest(notExistedBoardId);
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            //Act
            Func<Task> act = async () => await _deleteBoardUseCase.Handle(deleteBoardRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
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

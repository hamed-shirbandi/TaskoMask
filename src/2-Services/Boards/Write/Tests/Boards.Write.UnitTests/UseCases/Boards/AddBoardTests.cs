using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.AddBoard;
using TaskoMask.Services.Boards.Write.Domain.Events.Boards;
using TaskoMask.Services.Boards.Write.Domain.ValueObjects.Boards;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Boards
{
    public class AddBoardTests : TestsBaseFixture
    {

        #region Fields

        private AddBoardUseCase _addBoardUseCase;

        #endregion

        #region Ctor

        public AddBoardTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Board_Is_Added()
        {
            //Arrange
            var addBoardRequest = new AddBoardRequest(projectId: ObjectId.GenerateNewId().ToString(), "Test_Name", "Test_Description");

            //Act
            var result = await _addBoardUseCase.Handle(addBoardRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Create_Success);
            result.EntityId.Should().NotBeNull();
            var addedBoard = Boards.FirstOrDefault(u => u.Id == result.EntityId);
            addedBoard.Should().NotBeNull();
            addedBoard.Name.Value.Should().Be(addBoardRequest.Name);
            await InMemoryBus.Received(1).PublishEvent(Arg.Any<BoardAddedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<BoardAdded>());
        }



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _addBoardUseCase = new AddBoardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus,BoardValidatorService);
        }

        #endregion
    }
}

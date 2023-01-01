﻿using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.UpdateBoard;
using TaskoMask.Services.Boards.Write.Domain.Events.Boards;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Boards
{
    public class UpdateBoardTests : TestsBaseFixture
    {

        #region Fields

        private UpdateBoardUseCase _updateBoardUseCase;

        #endregion

        #region Ctor

        public UpdateBoardTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Board_Is_Updated()
        {
            //Arrange
            var expectedBoard = Boards.FirstOrDefault();
            var updateBoardRequest = new UpdateBoardRequest(expectedBoard.Id, "Test_New_Name", "Test_New_Description");

            //Act
            var result = await _updateBoardUseCase.Handle(updateBoardRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Update_Success);
            result.EntityId.Should().Be(expectedBoard.Id);

            expectedBoard.Name.Value.Should().Be(updateBoardRequest.Name);

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<BoardUpdatedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<BoardUpdated>());
        }


        [Fact]
        public async Task Updating_A_Board_Will_Throw_An_Exception_When_Id_Is_Not_Existed()
        {
            //Arrange
            var notExistedBoard = ObjectId.GenerateNewId().ToString();
            var updateBoardRequest = new UpdateBoardRequest(notExistedBoard, "Test_New_Name", "Test_New_Description");
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            //Act
            Func<Task> act = async () => await _updateBoardUseCase.Handle(updateBoardRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [Fact]
        public async Task Updating_A_Board_Will_Change_Its_Version()
        {
            //Arrange
            var expectedBoard = Boards.FirstOrDefault();
            var previousVersion = expectedBoard.Version;
            var updateBoardRequest = new UpdateBoardRequest(expectedBoard.Id, "Test_New_Name", "Test_New_Description");

            //Act
            await _updateBoardUseCase.Handle(updateBoardRequest, CancellationToken.None);

            //Assert
            expectedBoard.Version.Should().NotBeNullOrEmpty().And.NotBe(previousVersion);
        }


        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateBoardUseCase = new UpdateBoardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus,BoardValidatorService);
        }

        #endregion
    }
}
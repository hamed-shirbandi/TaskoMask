using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System;
using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.ObjectMothers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Boards;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Cards;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.ValueObjects.Boards;
using Xunit;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.BuildingBlocks.Test.TestBase;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.Workspace
{
    public class BoardAggregateUnitTests :UnitTestsBase
    {
        #region Fields

        private IBoardValidatorService _boardValidatorService;

        #endregion


        #region Test Mthods



        [Fact]
        public void Board_Is_Added()
        {

            //Arrange
            var boardBuilder = BoardBuilder.Init(_boardValidatorService)
                  .WithProjectId(ObjectId.GenerateNewId().ToString())
                  .WithName("Test Name")
                  .WithDescription("Test Description");

            //Act
            var board = boardBuilder.AddBoard();


            //Assert
            board.Name.Value.Should().NotBeNull().And.Be(boardBuilder.Name);
            board.Description.Value.Should().NotBeNull().And.Be(boardBuilder.Description);
            board.ProjectId.Value.Should().NotBeNull().And.Be(boardBuilder.ProjectId);
        }



        [Fact]
        public void Event_Is_Published_When_Board_Is_Added()
        {

            //Arrange
            var expectedEventType = nameof(BoardAddedEvent);
            var boardBuilder = BoardBuilder.Init(_boardValidatorService)
                  .WithProjectId(ObjectId.GenerateNewId().ToString())
                  .WithName("Test Name")
                  .WithDescription("Test Description");

            //Act
            var board = boardBuilder.AddBoard();

            //Assert
            board.DomainEvents.Should().HaveCount(1);
            var domainEvent = board.DomainEvents.First();
            domainEvent.EventType.Should().Be(expectedEventType);
            domainEvent.EntityId.Should().Be(board.Id);
        }



        [Fact]
        public void Board_Is_Not_Added_When_Name_Already_Exist()
        {
            //Arrange
            var reservedName = "Reserved_Name";//configured in _boardValidatorService in FixtureSetup()
            var expectedMessage = string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Board);

            //Act
            Action act = () => BoardObjectMother.AddBoardWithName(reservedName, _boardValidatorService);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [Fact]
        public void Board_Is_Not_Added_When_ProjectId_Is_Null()
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMetadata.Required, nameof(BoardProjectId));

            //Act
            Action act = () => BoardObjectMother.AddBoardWithProjectId(null,_boardValidatorService);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [InlineData("B")]
        [InlineData("ab")]
        [Theory]
        public void Board_Is_Not_Added_When_Name_Lenght_Is_Less_Than_Min_Length(string name)
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMetadata.Length_Error, nameof(BoardName), DomainConstValues.Board_Name_Min_Length, DomainConstValues.Board_Name_Max_Length);

            //Act
            Action act = () => BoardObjectMother.AddBoardWithName(name, _boardValidatorService);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [InlineData("TestName", "TestName")]
        [InlineData("SameName", "SameName")]
        [InlineData("نام تست", "نام تست")]
        [Theory]
        public void Board_Is_Not_Added_When_Name_And_Description_Are_The_Same(string name, string description)
        {
            //Arrange
            var expectedMessage = DomainMessages.Equal_Name_And_Description_Error;

            //Act
            Action act = () => BoardObjectMother.AddBoard(name, description, _boardValidatorService);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));

        }




        [Fact]
        public void Card_Is_Added()
        {

            //Arrange
            var board = BoardObjectMother.AddBoard(_boardValidatorService);
            var expectedCard = Card.Create("Test Card Name", BoardCardType.ToDo);


            //Act
            board.AddCard(expectedCard);

            //Assert
            board.Cards.Should().HaveCount(1);
            var card = board.Cards.First();
            card.Name.Should().Be(expectedCard.Name);
            card.Id.Should().Be(expectedCard.Id);
        }



        [Fact]
        public void Event_Is_Published_When_Card_Is_Added()
        {

            //Arrange
            var board = BoardObjectMother.AddBoard(_boardValidatorService);
            var expectedCard = Card.Create("Test Card Name", BoardCardType.ToDo);
            var expectedEventType = nameof(CardAddedEvent);

            //Act
            board.AddCard(expectedCard);

            //Assert
            board.DomainEvents.Should().HaveCount(1);
            var domainEvent = board.DomainEvents.Last();
            domainEvent.EventType.Should().Be(expectedEventType);
            domainEvent.EntityId.Should().Be(expectedCard.Id);

        }



        #endregion

        #region Private Methods


        /// <summary>
        /// Manage Test Fixture
        /// </summary>
        protected override void FixtureSetup()
        {
            _boardValidatorService = Substitute.For<IBoardValidatorService>();
            _boardValidatorService.BoardHasUniqueName(boardId: Arg.Any<string>(), projectId: Arg.Any<string>(), boardName: Arg.Any<string>()).Returns(arg => (string)arg[2] != "Reserved_Name");
        }


        #endregion
    }
}

using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Events.Boards;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Events.Cards;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;
using TaskoMask.Domain.WriteModel.Workspace.Boards.ValueObjects.Boards;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit.Workspace
{
    public class BoardAggregateUnitTests
    {
        private readonly IBoardValidatorService _boardValidatorService;
       

        /// <summary>
        /// Run before each test method
        /// </summary>
        public BoardAggregateUnitTests()
        {
            _boardValidatorService = Substitute.For<IBoardValidatorService>();
            _boardValidatorService.BoardHasUniqueName(boardId: Arg.Any<string>(), projectId: Arg.Any<string>(), boardName: Arg.Any<string>()).Returns(true);
        }



        [Fact]
        public void Board_Is_Constructed_Properly()
        {

            //Arrange
            var boardBuilder = BoardBuilder.Init(_boardValidatorService)
                  .WithProjectId(ObjectId.GenerateNewId().ToString())
                  .WithName("Test Name")
                  .WithDescription("Test Description");

            //Act
            var board = boardBuilder.Build();


            //Assert
            board.Name.Value.Should().NotBeNull().And.Be(boardBuilder.Name);
            board.Description.Value.Should().NotBeNull().And.Be(boardBuilder.Description);
            board.ProjectId.Value.Should().NotBeNull().And.Be(boardBuilder.ProjectId);
        }



        [Fact]
        public void Board_Created_Event_Is_Raised_When_Board_Is_Constructed_Properly()
        {

            //Arrange
            var expectedEventType = nameof(BoardCreatedEvent);

            //Act
            var board = BoardObjectMother.CreateNewBoard(_boardValidatorService);

            //Assert
            board.DomainEvents.Should().HaveCount(1);
            var domainEvent = board.DomainEvents.First();
            domainEvent.EventType.Should().Be(expectedEventType);
            domainEvent.EntityId.Should().Be(board.Id);
        }



        [Fact]
        public void Board_Is_Not_Constructed_When_ProjectId_Is_Null()
        {
            //Arrange

            //Act
            Action act = () => BoardObjectMother.CreateNewBoardWithProjectId(null,_boardValidatorService);

            //Assert
            act.Should().Throw<DomainException>()
                .Where(e => e.Message.Equals(string.Format(DomainMessages.Required, nameof(BoardProjectId))));
        }



        [InlineData("B")]
        [InlineData("ab")]
        [Theory]
        public void Board_Is_Not_Constructed_When_Name_Lenght_Is_Less_Than_Min_Length(string name)
        {
            //Arrange

            //Act
            Action act = () => BoardObjectMother.CreateNewBoardWithName(name, _boardValidatorService);

            //Assert
            act.Should().Throw<DomainException>()
                .Where(e => e.Message.Equals(string.Format(DomainMessages.Length_Error, nameof(BoardName), DomainConstValues.Board_Name_Min_Length, DomainConstValues.Board_Name_Max_Length)));
        }


        [InlineData("TestName", "TestName")]
        [InlineData("SameName", "SameName")]
        [InlineData("نام تست", "نام تست")]
        [Theory]
        public void Board_Is_Not_Constructed_When_Name_And_Description_Are_The_Same(string name, string description)
        {
            //Arrange

            //Act
            Action act = () => BoardObjectMother.CreateNewBoard(name, description, _boardValidatorService);

            //Assert
            act.Should().Throw<DomainException>()
                .Where(e => e.Message.Equals(DomainMessages.Equal_Name_And_Description_Error));
        }


        [Fact]
        public void Card_Is_Created_Properly()
        {

            //Arrange
            var board = BoardObjectMother.CreateNewBoard(_boardValidatorService);
            var expectedCard = Card.Create("Test Card Name", BoardCardType.ToDo);


            //Act
            board.CreateCard(expectedCard);

            //Assert
            board.Cards.Should().HaveCount(1);
            var card = board.Cards.First();
            card.Name.Should().Be(expectedCard.Name);
            card.Id.Should().Be(expectedCard.Id);
        }


        [Fact]
        public void Card_Created_Event_Is_Raised_When_Card_Is_Created()
        {

            //Arrange
            var board = BoardObjectMother.CreateNewBoard(_boardValidatorService);
            var expectedCard = Card.Create("Test Card Name", BoardCardType.ToDo);
            var expectedEventType = nameof(CardCreatedEvent);

            //Act
            board.CreateCard(expectedCard);

            //Assert
            board.DomainEvents.Should().HaveCount(2);
            var domainEvent = board.DomainEvents.Last();
            domainEvent.EventType.Should().Be(expectedEventType);
            domainEvent.EntityId.Should().Be(expectedCard.Id);

        }



    }
}

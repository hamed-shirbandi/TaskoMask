using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Tests.Unit.DataBuilders;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;
using Xunit;

namespace TaskoMask.Domain.Tests.Unit
{
    public class BoardAggregateUnitTests
    {
        public BoardAggregateUnitTests()
        {

        }


        [Fact]
        public void Board_Is_Constructed_Properly()
        {

            //Arrange
            var boardValidatorService = Substitute.For<IBoardValidatorService>();
            boardValidatorService.BoardHasUniqueName(boardId: Arg.Any<string>(), projectId: Arg.Any<string>(), boardName: Arg.Any<string>()).Returns(true);

            var boardBuilder = BoardBuilder.Init(boardValidatorService)
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

    }
}

using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Create_Board()
        {
            //Arrange
            var name = "Test Name";
            var description = "Test Description";
            var projectId = "No_Id";
            var boardValidatorService = Substitute.For<IBoardValidatorService>();
            boardValidatorService.BoardHasUniqueName(Arg.Any<string>(), projectId, name).Returns(true);

            //Act
            var bord =  Board.CreateBoard(name,description,projectId, boardValidatorService);


            //Assert
            bord.Name.Value.Should().NotBeNull().And.Be(name);
            bord.Description.Value.Should().NotBeNull().And.Be(description);
            bord.ProjectId.Value.Should().NotBeNull().And.Be(projectId);
        }

    }
}

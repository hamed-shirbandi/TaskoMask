using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Boards;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.ValueObjects.Boards;
using TaskoMask.Services.Boards.Write.Api.UseCases.Boards.AddBoard;
using TaskoMask.Services.Boards.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Unit.UseCases.Boards;

public class AddBoardTests : TestsBaseFixture
{
    #region Fields

    private AddBoardUseCase addBoardUseCase;

    #endregion

    #region Ctor

    public AddBoardTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Board_is_added()
    {
        //Arrange
        var addBoardRequest = new AddBoardRequest(projectId: ObjectId.GenerateNewId().ToString(), "Test_Name", "Test_Description");

        //Act
        var result = await addBoardUseCase.Handle(addBoardRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Create_Success);
        result.EntityId.Should().NotBeNull();

        var addedBoard = Boards.FirstOrDefault(u => u.Id == result.EntityId);
        addedBoard.Should().NotBeNull();
        addedBoard.Name.Value.Should().Be(addBoardRequest.Name);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<BoardAddedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<BoardAdded>());
    }

    [InlineData("test", "test")]
    [InlineData("تست", "تست")]
    [Theory]
    public async Task Board_is_not_added_if_name_and_description_are_the_same(string name, string description)
    {
        //Arrange
        var addBoardRequest = new AddBoardRequest(projectId: ObjectId.GenerateNewId().ToString(), name, description);
        var expectedMessage = DomainMessages.Equal_Name_And_Description_Error;

        //Act
        Func<Task> act = async () => await addBoardUseCase.Handle(addBoardRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [InlineData("Th")]
    [InlineData("This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test")]
    [Theory]
    public async Task Board_is_not_added_if_name_lenght_is_less_than_min_or_more_than_max(string name)
    {
        //Arrange
        var addBoardRequest = new AddBoardRequest(projectId: ObjectId.GenerateNewId().ToString(), name, "Test_Description");
        var expectedMessage = string.Format(
            ContractsMetadata.Length_Error,
            nameof(BoardName),
            DomainConstValues.BOARD_NAME_MIN_LENGTH,
            DomainConstValues.BOARD_NAME_MAX_LENGTH
        );

        //Act
        Func<Task> act = async () => await addBoardUseCase.Handle(addBoardRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [InlineData(
        "This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test"
    )]
    [Theory]
    public async Task Board_is_not_added_if_description_lenght_is_more_than_max(string description)
    {
        //Arrange
        var expectedBoard = Boards.FirstOrDefault();
        var addBoardRequest = new AddBoardRequest(projectId: ObjectId.GenerateNewId().ToString(), "Test_Name", description);
        var expectedMessage = string.Format(
            ContractsMetadata.Max_Length_Error,
            nameof(BoardDescription),
            DomainConstValues.BOARD_DESCRIPTION_MAX_LENGTH
        );

        //Act
        Func<Task> act = async () => await addBoardUseCase.Handle(addBoardRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [Fact]
    public async Task Board_is_not_added_if_name_is_not_unique_in_a_project()
    {
        //Arrange
        var expectedMessage = string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Board);
        var existedBoard = Boards.FirstOrDefault();
        var addBoardRequest = new AddBoardRequest(existedBoard.ProjectId.Value, existedBoard.Name.Value, "Test_Description");

        //Act
        Func<Task> act = async () => await addBoardUseCase.Handle(addBoardRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        addBoardUseCase = new AddBoardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus, BoardValidatorService);
    }

    #endregion
}

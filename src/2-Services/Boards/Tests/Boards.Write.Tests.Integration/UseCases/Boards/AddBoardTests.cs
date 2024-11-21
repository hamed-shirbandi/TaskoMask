using FluentAssertions;
using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Boards.Write.Api.UseCases.Boards.AddBoard;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Boards;

[Collection(nameof(BoardCollectionFixture))]
public class AddBoardTests
{
    #region Fields

    private readonly BoardCollectionFixture _fixture;

    #endregion

    #region Ctor

    public AddBoardTests(BoardCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Board_is_added()
    {
        //Arrange
        var request = new AddBoardRequest(name: "Test Name", description: "Test Description", projectId: ObjectId.GenerateNewId().ToString());
        var addBoardUseCase = new AddBoardUseCase(
            _fixture._boardAggregateRepository,
            _fixture._eventPublisher,
            _fixture._requestDispatcher,
            _fixture._boardValidatorService
        );

        //Act
        var result = await addBoardUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().NotBeNull();
        result.Message.Should().Be(ContractsMessages.Create_Success);
    }

    #endregion
}

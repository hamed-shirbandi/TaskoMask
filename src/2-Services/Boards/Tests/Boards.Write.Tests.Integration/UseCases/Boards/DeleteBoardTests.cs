using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Boards.Write.Api.UseCases.Boards.DeleteBoard;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Boards;

[Collection(nameof(BoardCollectionFixture))]
public class DeleteBoardTests
{
    #region Fields

    private readonly BoardCollectionFixture _fixture;

    #endregion

    #region Ctor

    public DeleteBoardTests(BoardCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Board_is_deleted()
    {
        //Arrange
        var expectedBoard = BoardObjectMother.CreateBoard(_fixture._boardValidatorService);
        await _fixture.SeedBoardAsync(expectedBoard);

        var request = new DeleteBoardRequest(expectedBoard.Id);
        var deleteBoardUseCase = new DeleteBoardUseCase(_fixture._boardAggregateRepository, _fixture._eventPublisher, _fixture._requestDispatcher);

        //Act
        var result = await deleteBoardUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedBoard.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var deletedBoard = await _fixture.GetBoardAsync(expectedBoard.Id);
        deletedBoard.Should().BeNull();
    }

    #endregion
}

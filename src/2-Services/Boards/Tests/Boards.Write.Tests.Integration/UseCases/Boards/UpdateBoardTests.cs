using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Boards.Write.Api.UseCases.Boards.UpdateBoard;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Boards;

[Collection(nameof(BoardCollectionFixture))]
public class UpdateBoardTests
{
    #region Fields

    private readonly BoardCollectionFixture _fixture;

    #endregion

    #region Ctor

    public UpdateBoardTests(BoardCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Board_is_updated()
    {
        //Arrange
        var expectedBoard = BoardObjectMother.CreateBoard(_fixture._boardValidatorService);
        await _fixture.SeedBoardAsync(expectedBoard);

        var request = new UpdateBoardRequest(id: expectedBoard.Id, name: "Test New Name", description: "Test New Description");
        var updateBoardUseCase = new UpdateBoardUseCase(
            _fixture._boardAggregateRepository,
            _fixture._eventPublisher,
            _fixture._requestDispatcher,
            _fixture._boardValidatorService
        );

        //Act
        var result = await updateBoardUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedBoard.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedBoard = await _fixture.GetBoardAsync(expectedBoard.Id);
        updatedBoard.Name.Value.Should().Be(request.Name);
        updatedBoard.Description.Value.Should().Be(request.Description);
    }

    #endregion
}

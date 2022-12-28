using FluentAssertions;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByProjectId;
using TaskoMask.Services.Boards.Read.IntegrationTests.Fixtures;
using TaskoMask.Services.Boards.Read.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Read.IntegrationTests.Features.Boards
{
    [Collection(nameof(BoardCollectionFixture))]
    public class GetBoardsByProjectIdTests
    {

        #region Fields

        private readonly BoardCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetBoardsByProjectIdTests(BoardCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Boards_Are_Fetched_By_ProjectId()
        {
            //Arrange
            var expectedBoard = BoardObjectMother.GetBoard();
            await _fixture.SeedBoardAsync(expectedBoard);
            var getBoardsByProjectIdHandler = new GetBoardsByProjectIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetBoardsByProjectIdRequest(expectedBoard.ProjectId);

            //Act
            var result = await getBoardsByProjectIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCount(1);
            result.FirstOrDefault().Name.Should().Be(expectedBoard.Name);
        }


        #endregion
    }
}

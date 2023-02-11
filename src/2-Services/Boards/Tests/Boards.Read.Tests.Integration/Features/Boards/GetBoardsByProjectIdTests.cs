using FluentAssertions;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByProjectId;
using TaskoMask.Services.Boards.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Boards.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Read.Tests.Integration.Features.Boards
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
        public async Task Boards_are_fetched_by_project_Id()
        {
            //Arrange
            var expectedBoard = BoardObjectMother.CreateBoard();
            await _fixture.SeedBoardAsync(expectedBoard);
            var getBoardsByProjectIdHandler = new GetBoardsByProjectIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetBoardsByProjectIdRequest(expectedBoard.ProjectId);

            //Act
            var result = await getBoardsByProjectIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCountGreaterThanOrEqualTo(1);
            result.Should().Contain(c => c.Id == expectedBoard.Id);
        }


        #endregion
    }
}

using FluentAssertions;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByOrganizationId;
using TaskoMask.Services.Boards.Read.IntegrationTests.Fixtures;
using TaskoMask.Services.Boards.Read.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Read.IntegrationTests.Features.Boards
{
    [Collection(nameof(BoardCollectionFixture))]
    public class GetBoardsByOrganizationIdTests
    {

        #region Fields

        private readonly BoardCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetBoardsByOrganizationIdTests(BoardCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Boards_Are_Fetched_By_OrganizationId()
        {
            //Arrange
            var expectedBoard = BoardObjectMother.GetBoard();
            await _fixture.SeedBoardAsync(expectedBoard);
            var getBoardsByOrganizationIdHandler = new GetBoardsByOrganizationIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetBoardsByOrganizationIdRequest(expectedBoard.OrganizationId);

            //Act
            var result = await getBoardsByOrganizationIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCount(1);
            result.FirstOrDefault().Name.Should().Be(expectedBoard.Name);
        }


        #endregion
    }
}

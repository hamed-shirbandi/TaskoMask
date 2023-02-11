using FluentAssertions;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByOrganizationId;
using TaskoMask.Services.Boards.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Boards.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Read.Tests.Integration.Features.Boards
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
        public async Task Boards_are_fetched_by_organization_Id()
        {
            //Arrange
            var expectedBoard = BoardObjectMother.CreateBoard();
            await _fixture.SeedBoardAsync(expectedBoard);
            var getBoardsByOrganizationIdHandler = new GetBoardsByOrganizationIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetBoardsByOrganizationIdRequest(expectedBoard.OrganizationId);

            //Act
            var result = await getBoardsByOrganizationIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCountGreaterThanOrEqualTo(1);
            result.Should().Contain(c => c.Id == expectedBoard.Id);
        }


        #endregion
    }
}

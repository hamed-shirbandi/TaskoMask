using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId;
using TaskoMask.Services.Tasks.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.Features.Comments
{
    [Collection(nameof(CommentCollectionFixture))]
    public class GetCommentsByTaskIdTests
    {
        #region Fields

        private readonly CommentCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetCommentsByTaskIdTests(CommentCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Comments_are_fetched_by_task_Id()
        {
            //Arrange
            var expectedComment = CommentObjectMother.CreateComment();
            await _fixture.SeedCommentAsync(expectedComment);
            var getCommentsByTaskIdHandler = new GetCommentsByTaskIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetCommentsByTaskIdRequest(expectedComment.TaskId);

            //Act
            var result = await getCommentsByTaskIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCountGreaterThanOrEqualTo(1);
            result.Should().Contain(c => c.Id == expectedComment.Id);
        }


        #endregion
    }
}

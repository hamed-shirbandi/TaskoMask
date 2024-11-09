using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentById;
using TaskoMask.Services.Tasks.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.Features.Comments;

[Collection(nameof(CommentCollectionFixture))]
public class GetCommentByIdTests
{
    #region Fields

    private readonly CommentCollectionFixture _fixture;

    #endregion

    #region Ctor

    public GetCommentByIdTests(CommentCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Comment_is_fetched_by_Id()
    {
        //Arrange
        var expectedComment = CommentObjectMother.CreateComment();
        await _fixture.SeedCommentAsync(expectedComment);
        var getCommentByIdHandler = new GetCommentByIdHandler(_fixture._dbContext, _fixture._mapper);
        var request = new GetCommentByIdRequest(expectedComment.Id);

        //Act
        var result = await getCommentByIdHandler.Handle(request, CancellationToken.None);

        //Assert
        result.Id.Should().Be(expectedComment.Id);
        result.Content.Should().Be(expectedComment.Content);
    }

    #endregion
}

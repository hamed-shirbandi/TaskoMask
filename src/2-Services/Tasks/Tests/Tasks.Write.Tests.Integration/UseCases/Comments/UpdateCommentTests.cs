using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.UpdateComment;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Comments;

[Collection(nameof(CommentCollectionFixture))]
public class UpdateCommentTests
{
    #region Fields

    private readonly CommentCollectionFixture _fixture;

    #endregion

    #region Ctor

    public UpdateCommentTests(CommentCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Comment_is_updated()
    {
        //Arrange
        var expectedTask = TaskObjectMother.CreateTaskWithOneComment(_fixture._taskValidatorService);
        var expectedComment = expectedTask.Comments.FirstOrDefault();
        await _fixture.SeedTaskAsync(expectedTask);

        var request = new UpdateCommentRequest(id: expectedComment.Id, content: "Test New Content");
        var updateCommentUseCase = new UpdateCommentUseCase(_fixture._taskAggregateRepository, _fixture._eventPublisher, _fixture._requestDispatcher);

        //Act
        var result = await updateCommentUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedComment.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedTask = await _fixture.GetTaskAsync(expectedTask.Id);
        var updatedComment = updatedTask.GetCommentById(expectedComment.Id);

        updatedComment.Content.Value.Should().Be(request.Content);
    }

    #endregion
}

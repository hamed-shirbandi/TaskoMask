using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.DeleteComment;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Comments;

[Collection(nameof(CommentCollectionFixture))]
public class DeleteCommentTests
{
    #region Fields

    private readonly CommentCollectionFixture _fixture;

    #endregion

    #region Ctor

    public DeleteCommentTests(CommentCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Comment_is_deleted()
    {
        //Arrange
        var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Comment);
        var expectedTask = TaskObjectMother.CreateTaskWithOneComment(_fixture._taskValidatorService);
        await _fixture.SeedTaskAsync(expectedTask);

        var expectedComment = expectedTask.Comments.FirstOrDefault();

        var request = new DeleteCommentRequest(expectedComment.Id);
        var deleteCommentUseCase = new DeleteCommentUseCase(_fixture._taskAggregateRepository, _fixture._eventPublisher, _fixture._requestDispatcher);

        //Act
        var result = await deleteCommentUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedComment.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedTask = await _fixture.GetTaskAsync(expectedTask.Id);
        Action act = () => updatedTask.GetCommentById(expectedComment.Id);
        act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion
}

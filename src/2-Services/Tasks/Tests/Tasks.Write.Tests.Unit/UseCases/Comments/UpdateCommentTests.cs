using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Comments;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.UpdateComment;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.UseCases.Comments;

public class UpdateCommentTests : TestsBaseFixture
{
    #region Fields

    private UpdateCommentUseCase updateCommentUseCase;

    #endregion

    #region Ctor

    public UpdateCommentTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Comment_is_updated()
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var expectedComment = TaskObjectMother.CreateComment();
        expectedTask.AddComment(expectedComment);
        var updateCommentRequest = new UpdateCommentRequest(expectedComment.Id, "Test New Content");

        //Act
        var result = await updateCommentUseCase.Handle(updateCommentRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Update_Success);
        result.EntityId.Should().Be(expectedComment.Id);

        var updatedComment = expectedTask.GetCommentById(expectedComment.Id);
        updatedComment.Content.Value.Should().Be(updateCommentRequest.Content);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<CommentUpdatedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<CommentUpdated>());
    }

    [Fact]
    public async Task Updating_a_comment_will_throw_an_exception_if_Id_is_not_existed()
    {
        //Arrange
        var notExistedCommentId = ObjectId.GenerateNewId().ToString();
        var updateCommentRequest = new UpdateCommentRequest(notExistedCommentId, "Test New Content");
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Comment);

        //Act
        Func<Task> act = async () => await updateCommentUseCase.Handle(updateCommentRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        updateCommentUseCase = new UpdateCommentUseCase(TaskAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}

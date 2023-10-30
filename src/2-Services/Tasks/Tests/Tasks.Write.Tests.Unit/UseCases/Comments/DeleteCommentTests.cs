using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Comments;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.DeleteComment;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.UseCases.Comments;

public class DeleteCommentTests : TestsBaseFixture
{
    #region Fields

    private DeleteCommentUseCase deleteCommentUseCase;

    #endregion

    #region Ctor

    public DeleteCommentTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Comment_is_deleted()
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var expectedComment = TaskObjectMother.CreateComment();
        expectedTask.AddComment(expectedComment);
        var deleteCommentRequest = new DeleteCommentRequest(expectedComment.Id);
        var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Comment);

        //Act
        var result = await deleteCommentUseCase.Handle(deleteCommentRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Update_Success);
        result.EntityId.Should().Be(expectedComment.Id);

        //Act
        Action act = () => expectedTask.GetCommentById(expectedComment.Id);

        //Assert
        act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<CommentDeletedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<CommentDeleted>());
    }

    [Fact]
    public async Task Deleting_a_comment_will_throw_an_exception_if_Id_is_not_existed()
    {
        //Arrange
        var notExistedCommentId = ObjectId.GenerateNewId().ToString();
        var deleteCommentRequest = new DeleteCommentRequest(notExistedCommentId);
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Comment);

        //Act
        Func<Task> act = async () => await deleteCommentUseCase.Handle(deleteCommentRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        deleteCommentUseCase = new DeleteCommentUseCase(TaskAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}

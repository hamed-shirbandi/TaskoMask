using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Comments;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.AddComment;
using TaskoMask.Services.Tasks.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Unit.UseCases.Comments;

public class AddCommentTests : TestsBaseFixture
{
    #region Fields

    private AddCommentUseCase addCommentUseCase;

    #endregion

    #region Ctor

    public AddCommentTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Comment_is_added()
    {
        //Arrange
        var expectedTask = Tasks.FirstOrDefault();
        var addCommentRequest = new AddCommentRequest(expectedTask.Id, "Test_Content");

        //Act
        var result = await addCommentUseCase.Handle(addCommentRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Create_Success);
        result.EntityId.Should().NotBeNull();

        var addedComment = expectedTask.GetCommentById(result.EntityId);
        addedComment.Should().NotBeNull();
        addedComment.Content.Value.Should().Be(addCommentRequest.Content);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<CommentAddedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<CommentAdded>());
    }

    [Fact]
    public async Task Adding_a_comment_will_throw_an_exception_if_task_Id_is_not_existed()
    {
        //Arrange
        var notExistedTaskId = ObjectId.GenerateNewId().ToString();
        var addCommentRequest = new AddCommentRequest(notExistedTaskId, "Test_Content");
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

        //Act
        Func<Task> act = async () => await addCommentUseCase.Handle(addCommentRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        addCommentUseCase = new AddCommentUseCase(TaskAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}

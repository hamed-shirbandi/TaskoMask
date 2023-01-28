using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Application.UseCases.Comments.AddComment;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using Xunit;
using System.Threading.Tasks;
using System.Threading;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Comments
{
    [Collection(nameof(CommentCollectionFixture))]
    public class AddCommentTests
    {

        #region Fields

        private readonly CommentCollectionFixture _fixture;

        #endregion

        #region Ctor

        public AddCommentTests(CommentCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Comment_is_added()
        {
            //Arrange
            var expectedTask = TaskObjectMother.CreateTask(_fixture.TaskValidatorService);
            await _fixture.SeedTaskAsync(expectedTask);

            var request = new AddCommentRequest(taskId: expectedTask.Id, content: "Test Content");
            var addCommentUseCase = new AddCommentUseCase(_fixture.TaskAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await addCommentUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNull();
            result.Message.Should().Be(ContractsMessages.Create_Success);

            var updatedTask = await _fixture.GetTaskAsync(expectedTask.Id);
            var addedComment = updatedTask.GetCommentById(result.EntityId);

            addedComment.Content.Value.Should().Be(request.Content);
        }


        #endregion
    }
}

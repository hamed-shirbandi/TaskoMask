using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Application.UseCases.Comments.UpdateComment;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Comments
{
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
            var expectedTask = TaskObjectMother.CreateTaskWithOneComment(_fixture.TaskValidatorService);
            var expectedComment = expectedTask.Comments.FirstOrDefault();
            await _fixture.SeedTaskAsync(expectedTask);

            var request = new UpdateCommentRequest(id: expectedComment.Id, content: "Test New Content");
            var updateCommentUseCase = new UpdateCommentUseCase(_fixture.TaskAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

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
}

using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.DeleteTask;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using Xunit;
using System.Threading.Tasks;
using System.Threading;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Tasks
{
    [Collection(nameof(TaskCollectionFixture))]
    public class DeleteTaskTests
    {

        #region Fields

        private readonly TaskCollectionFixture _fixture;

        #endregion

        #region Ctor

        public DeleteTaskTests(TaskCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Task_is_deleted()
        {
            //Arrange
            var expectedTask = TaskObjectMother.CreateTask(_fixture.TaskValidatorService);
            await _fixture.SeedTaskAsync(expectedTask);

            var request = new DeleteTaskRequest(expectedTask.Id);
            var deleteTaskUseCase = new DeleteTaskUseCase(_fixture.TaskAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await deleteTaskUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedTask.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var deletedTask = await _fixture.GetTaskAsync(expectedTask.Id);
            deletedTask.Should().BeNull();
        }


        #endregion
    }
}

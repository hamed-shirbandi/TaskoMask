using FluentAssertions;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.AddTask;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Tasks
{
    [Collection(nameof(TaskCollectionFixture))]
    public class AddTaskTests
    {

        #region Fields

        private readonly TaskCollectionFixture _fixture;

        #endregion

        #region Ctor

        public AddTaskTests(TaskCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Task_is_added()
        {
            //Arrange
            var request = new AddTaskRequest(title: "Test Title", description: "Test Description", cardId: ObjectId.GenerateNewId().ToString(), boardId: ObjectId.GenerateNewId().ToString());
            var addTaskUseCase = new AddTaskUseCase(_fixture.TaskAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus,_fixture.TaskValidatorService);

            //Act
            var result = await addTaskUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNull();
            result.Message.Should().Be(ContractsMessages.Create_Success);

        }


        #endregion
    }
}

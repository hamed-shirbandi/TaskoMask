using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.UpdateTask;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Tasks;

[Collection(nameof(TaskCollectionFixture))]
public class UpdateTaskTests
{
    #region Fields

    private readonly TaskCollectionFixture _fixture;

    #endregion

    #region Ctor

    public UpdateTaskTests(TaskCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Task_is_updated()
    {
        //Arrange
        var expectedTask = TaskObjectMother.CreateTask(_fixture._taskValidatorService);
        await _fixture.SeedTaskAsync(expectedTask);

        var request = new UpdateTaskRequest(id: expectedTask.Id, title: "Test New Title", description: "Test New Description");
        var updateTaskUseCase = new UpdateTaskUseCase(
            _fixture._taskAggregateRepository,
            _fixture._eventPublisher,
            _fixture._requestDispatcher,
            _fixture._taskValidatorService
        );

        //Act
        var result = await updateTaskUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedTask.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedTask = await _fixture.GetTaskAsync(expectedTask.Id);
        updatedTask.Title.Value.Should().Be(request.Title);
        updatedTask.Description.Value.Should().Be(request.Description);
    }

    #endregion
}

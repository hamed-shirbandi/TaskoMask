using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.DeleteTask;
using TaskoMask.Services.Tasks.Write.Tests.Base.TestData;
using TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.UseCases.Tasks;

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
        var expectedTask = TaskObjectMother.CreateTask(_fixture._taskValidatorService);
        await _fixture.SeedTaskAsync(expectedTask);

        var request = new DeleteTaskRequest(expectedTask.Id);
        var deleteTaskUseCase = new DeleteTaskUseCase(_fixture._taskAggregateRepository, _fixture._eventPublisher, _fixture._requestDispatcher);

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

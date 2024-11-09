using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;
using TaskoMask.Services.Tasks.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.Features.Tasks;

[Collection(nameof(TaskCollectionFixture))]
public class GetTaskByIdTests
{
    #region Fields

    private readonly TaskCollectionFixture _fixture;

    #endregion

    #region Ctor

    public GetTaskByIdTests(TaskCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Task_is_fetched_by_Id()
    {
        //Arrange
        var expectedTask = TaskObjectMother.CreateTask();
        await _fixture.SeedTaskAsync(expectedTask);
        var getTaskByIdHandler = new GetTaskByIdHandler(_fixture._dbContext, _fixture._mapper);
        var request = new GetTaskByIdRequest(expectedTask.Id);

        //Act
        var result = await getTaskByIdHandler.Handle(request, CancellationToken.None);

        //Assert
        result.Id.Should().Be(expectedTask.Id);
        result.Title.Should().Be(expectedTask.Title);
    }

    #endregion
}

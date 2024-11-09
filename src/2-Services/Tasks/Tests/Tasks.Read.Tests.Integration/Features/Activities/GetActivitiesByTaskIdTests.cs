using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId;
using TaskoMask.Services.Tasks.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.Features.Activities;

[Collection(nameof(ActivityCollectionFixture))]
public class GetActivitiesByTaskIdTests
{
    #region Fields

    private readonly ActivityCollectionFixture _fixture;

    #endregion

    #region Ctor

    public GetActivitiesByTaskIdTests(ActivityCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Activities_are_fetched_by_task_Id()
    {
        //Arrange
        var expectedActivity = ActivityObjectMother.CreateActivity();
        await _fixture.SeedActivityAsync(expectedActivity);
        var getActivitiesByTaskIdHandler = new GetActivitiesByTaskIdHandler(_fixture._dbContext, _fixture._mapper);
        var request = new GetActivitiesByTaskIdRequest(expectedActivity.TaskId);

        //Act
        var result = await getActivitiesByTaskIdHandler.Handle(request, CancellationToken.None);

        //Assert
        result.Should().HaveCountGreaterThanOrEqualTo(1);
        result.Should().Contain(c => c.Id == expectedActivity.Id);
    }

    #endregion
}

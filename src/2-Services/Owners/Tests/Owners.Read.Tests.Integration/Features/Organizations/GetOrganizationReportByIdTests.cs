using Moq;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Features.Organizations;


[Collection(nameof(OrganizationCollectionFixture))]
public class GetOrganizationReportByIdTests
{
    #region Fields
    private readonly OrganizationCollectionFixture _fixture;
    private readonly Mock<GetBoardsByOrganizationIdGrpcService.GetBoardsByOrganizationIdGrpcServiceClient> _mockBoardsClient;
    private readonly Mock<GetCardsByBoardIdGrpcService.GetCardsByBoardIdGrpcServiceClient> _mockCardsClient;
    private readonly Mock<GetTasksByCardIdGrpcService.GetTasksByCardIdGrpcServiceClient> _mockTasksClient;
    #endregion

    #region Ctor
    public GetOrganizationReportByIdTests(OrganizationCollectionFixture fixture)
    {
        _fixture = fixture;
        _mockBoardsClient = new Mock<GetBoardsByOrganizationIdGrpcService.GetBoardsByOrganizationIdGrpcServiceClient>();
        _mockCardsClient = new Mock<GetCardsByBoardIdGrpcService.GetCardsByBoardIdGrpcServiceClient>();
        _mockTasksClient = new Mock<GetTasksByCardIdGrpcService.GetTasksByCardIdGrpcServiceClient>();
    }

    #endregion

    #region Test Methods

    //[Fact]
    //public async Task OrganizationReport_are_fetched_by_Id()
    //{
    //    //Arrange
    //    var expectedOrganization = OrganizationObjectMother.GetOrganization();
    //    await _fixture.SeedOrganizationAsync(expectedOrganization);
    //    var getOrganizationsReportByIdHandler = new GetOrganizationReportByIdHandler(
    //            _fixture._dbContext,
    //            _mockBoardsClient.Object,
    //            _mockCardsClient.Object,
    //            _mockTasksClient.Object,
    //            _fixture._mapper
    //        );
    //    var request = new GetOrganizationReportByIdRequest(expectedOrganization.OwnerId);

    //    //Act
    //    var result = await getOrganizationsReportByIdHandler.Handle(request, CancellationToken.None);

    //    //Assert
    //    Assert.NotNull(result);
    //    Assert.True(result.ProjectsCount >= 0);
    //    Assert.True(result.BoardsCount >= 0);
    //    Assert.True(result.ToDoTasksCount >= 0);
    //    Assert.True(result.DoingTasksCount >= 0);
    //    Assert.True(result.DoneTasksCount >= 0);
    //    Assert.True(result.BacklogTasksCount >= 0);
    //}

    #endregion
}

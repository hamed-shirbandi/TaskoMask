using AutoBogus;
using Grpc.Core;
using Moq;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationReportById;
using TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Read.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Features.Organizations;


[Collection(nameof(OrganizationCollectionFixture))]
public class GetOrganizationReportByIdTests
{
    #region Fields
    private readonly OrganizationCollectionFixture _fixture;

    #endregion

    #region Ctor
    public GetOrganizationReportByIdTests(OrganizationCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods

    [Fact]
    public async Task OrganizationReport_is_fetched_by_Id()
    {
        // Arrange
        var expectedOrganization = OrganizationObjectMother.GetOrganization();
        await _fixture.SeedOrganizationAsync(expectedOrganization);

        var dbContext = _fixture._dbContext;
        var mapper = _fixture._mapper;

        var mockBoardsClient = new Mock<GetBoardsByOrganizationIdGrpcService.GetBoardsByOrganizationIdGrpcServiceClient>();
        var mockCardsClient = new Mock<GetCardsByBoardIdGrpcService.GetCardsByBoardIdGrpcServiceClient>();
        var mockTasksClient = new Mock<GetTasksByCardIdGrpcService.GetTasksByCardIdGrpcServiceClient>();

        // Setup mock responses
        var fakeBoardsResponse = new AutoFaker<GetBoardGrpcResponse>().Generate();
        var fakeCardsResponse = new AutoFaker<GetCardGrpcResponse>().Generate();
        var fakeTasksResponse = new AutoFaker<GetTaskGrpcResponse>().Generate();


        // Create AsyncServerStreamingCall<TResponse> objects for the mocked responses
        var fakeBoardsAsyncResponse = new AsyncServerStreamingCall<GetBoardGrpcResponse>(
            GetAsyncStreamReader(fakeBoardsResponse),
            Task.FromResult(new Metadata()),
            () => Status.DefaultSuccess,
            () => new Metadata(),
            () => { }
        );


        var fakeCardsAsyncResponse = new AsyncServerStreamingCall<GetCardGrpcResponse>(
            GetAsyncStreamReader(fakeCardsResponse),
            Task.FromResult(new Metadata()),
            () => Status.DefaultSuccess,
            () => new Metadata(),
            () => { }
        );

        var fakeTasksAsyncResponse = new AsyncServerStreamingCall<GetTaskGrpcResponse>(
            GetAsyncStreamReader(fakeTasksResponse),
            Task.FromResult(new Metadata()),
            () => Status.DefaultSuccess,
            () => new Metadata(),
            () => { }
        );

        mockBoardsClient.Setup(client => client.Handle(It.IsAny<GetBoardsByOrganizationIdGrpcRequest>(), null, null, CancellationToken.None))
            .Returns(fakeBoardsAsyncResponse);

        mockCardsClient.Setup(client => client.Handle(It.IsAny<GetCardsByBoardIdGrpcRequest>(), null, null, CancellationToken.None))
            .Returns(fakeCardsAsyncResponse);

        mockTasksClient.Setup(client => client.Handle(It.IsAny<GetTasksByCardIdGrpcRequest>(), null, null, CancellationToken.None))
            .Returns(fakeTasksAsyncResponse);


        var handler = new GetOrganizationReportByIdHandler(
            dbContext,
            mockBoardsClient.Object,
            mockCardsClient.Object,
            mockTasksClient.Object,
            mapper
        );

        var request = new GetOrganizationReportByIdRequest(expectedOrganization.Id);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.ProjectsCount >= 0);
        Assert.True(result.BoardsCount >= 0);
        Assert.True(result.ToDoTasksCount >= 0);
        Assert.True(result.DoingTasksCount >= 0);
        Assert.True(result.DoneTasksCount >= 0);
        Assert.True(result.BacklogTasksCount >= 0);
    }


    #endregion

    #region Methods
    private static IAsyncStreamReader<T> GetAsyncStreamReader<T>(params T[] responses)
    {
        var mockStreamReader = new Mock<IAsyncStreamReader<T>>();
        var queue = new Queue<T>(responses);

        mockStreamReader.Setup(r => r.MoveNext(It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => queue.Count > 0);

        mockStreamReader.Setup(r => r.Current).Returns(() => queue.Dequeue());

        return mockStreamReader.Object;
    }
    #endregion
}
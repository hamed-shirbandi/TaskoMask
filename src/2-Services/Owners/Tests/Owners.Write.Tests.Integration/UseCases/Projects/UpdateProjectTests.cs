using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Api.UseCases.Projects.UpdateProject;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.UseCases.Projects;

[Collection(nameof(ProjectCollectionFixture))]
public class UpdateProjectTests
{
    #region Fields

    private readonly ProjectCollectionFixture _fixture;

    #endregion

    #region Ctor

    public UpdateProjectTests(ProjectCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Project_is_updated()
    {
        //Arrange
        var expectedOwner = OwnerObjectMother.CreateOwnerWithOneOrganizationAndOneProject(_fixture._ownerValidatorService);
        var expectedOrganization = expectedOwner.Organizations.FirstOrDefault();
        var expectedProject = expectedOrganization.Projects.FirstOrDefault();
        await _fixture.SeedOwnerAsync(expectedOwner);

        var request = new UpdateProjectRequest(id: expectedProject.Id, name: "Test New Name", description: "Test New Description");
        var updateProjectUseCase = new UpdateProjectUseCase(
            _fixture._ownerAggregateRepository,
            _fixture._eventPublisher,
            _fixture._requestDispatcher
        );

        //Act
        var result = await updateProjectUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedProject.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
        var updatedProject = updatedOwner.GetProjectById(expectedProject.Id);
        updatedProject.Name.Value.Should().Be(request.Name);
    }

    #endregion
}

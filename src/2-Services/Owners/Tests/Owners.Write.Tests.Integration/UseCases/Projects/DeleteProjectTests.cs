using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Api.UseCases.Projects.DeleteProject;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.UseCases.Projects;

[Collection(nameof(ProjectCollectionFixture))]
public class DeleteProjectTests
{
    #region Fields

    private readonly ProjectCollectionFixture _fixture;

    #endregion

    #region Ctor

    public DeleteProjectTests(ProjectCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Project_is_deleted()
    {
        //Arrange
        var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Project);
        var expectedOwner = OwnerObjectMother.CreateOwnerWithOneOrganizationAndOneProject(_fixture._ownerValidatorService);
        await _fixture.SeedOwnerAsync(expectedOwner);

        var expectedOrganization = expectedOwner.Organizations.FirstOrDefault();
        var expectedProject = expectedOrganization.Projects.FirstOrDefault();

        var request = new DeleteProjectRequest(expectedProject.Id);
        var deleteProjectUseCase = new DeleteProjectUseCase(
            _fixture._ownerAggregateRepository,
            _fixture._eventPublisher,
            _fixture._requestDispatcher
        );

        //Act
        var result = await deleteProjectUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedProject.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
        Action act = () => updatedOwner.GetProjectById(expectedProject.Id);
        act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion
}

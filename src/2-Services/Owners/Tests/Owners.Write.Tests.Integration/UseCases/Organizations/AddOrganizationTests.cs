using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.AddOrganization;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.UseCases.Organizations;

[Collection(nameof(OrganizationCollectionFixture))]
public class AddOrganizationTests
{
    #region Fields

    private readonly OrganizationCollectionFixture _fixture;

    #endregion

    #region Ctor

    public AddOrganizationTests(OrganizationCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Organization_is_added()
    {
        //Arrange
        var expectedOwner = OwnerObjectMother.CreateOwner(_fixture._ownerValidatorService);
        await _fixture.SeedOwnerAsync(expectedOwner);

        var request = new AddOrganizationRequest(ownerId: expectedOwner.Id, name: "Test Name", description: "Test Description");
        var addOrganizationUseCase = new AddOrganizationUseCase(
            _fixture._ownerAggregateRepository,
            _fixture._eventPublisher,
            _fixture._requestDispatcher
        );

        //Act
        var result = await addOrganizationUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().NotBeNull();
        result.Message.Should().Be(ContractsMessages.Create_Success);

        var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
        var addedOrganization = updatedOwner.GetOrganizationById(result.EntityId);
        addedOrganization.Name.Value.Should().Be(request.Name);
    }

    #endregion
}

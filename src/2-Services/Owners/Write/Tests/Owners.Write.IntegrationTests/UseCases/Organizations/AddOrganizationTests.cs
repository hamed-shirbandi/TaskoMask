using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization;
using TaskoMask.Services.Owners.Write.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Write.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.UseCases.Organizations
{
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
        public async Task Organization_Is_Added()
        {
            //Arrange
            var expectedOwner = OwnerObjectMother.GetAnOwner(_fixture.OwnerValidatorService);
            await _fixture.SeedOwnerAsync(expectedOwner);

            var request = new AddOrganizationRequest(ownerId: expectedOwner.Id, name: "Test Name", description: "Test Description");
            var addOrganizationUseCase = new AddOrganizationUseCase(_fixture.OwnerAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

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
}

using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.DeleteOrganization;
using TaskoMask.Services.Owners.Write.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Write.IntegrationTests.TestData.ObjectMothers;
using Xunit;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.UseCases.Organizations
{
    public class DeleteOrganizationTests : IClassFixture<OrganizationClassFixture>
    {

        #region Fields

        private readonly OrganizationClassFixture _fixture;

        #endregion

        #region Ctor

        public DeleteOrganizationTests(OrganizationClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Organization_Is_Deleted_Properly()
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Organization);
            var expectedOwner = OwnerObjectMother.GetAnOwnerWithAnOrganization(_fixture.OwnerValidatorService);
            var expectedOrganization = expectedOwner.Organizations.FirstOrDefault();
            await _fixture.SeedOwnerAsync(expectedOwner);

            var request = new DeleteOrganizationRequest(expectedOrganization.Id);
            var deleteOrganizationUseCase = new DeleteOrganizationUseCase(_fixture.OwnerAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await deleteOrganizationUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedOrganization.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
            Action act = () => updatedOwner.GetOrganizationById(expectedOrganization.Id);
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }


        #endregion
    }
}

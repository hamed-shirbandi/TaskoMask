using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.DeleteOrganization;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.UseCases.Organizations
{
    [Collection(nameof(OrganizationCollectionFixture))]
    public class DeleteOrganizationTests
    {

        #region Fields

        private readonly OrganizationCollectionFixture _fixture;

        #endregion

        #region Ctor

        public DeleteOrganizationTests(OrganizationCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Organization_is_deleted()
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Organization);
            var expectedOwner = OwnerObjectMother.CreateOwnerWithOneOrganization(_fixture.OwnerValidatorService);
            await _fixture.SeedOwnerAsync(expectedOwner);
            var expectedOrganization = expectedOwner.Organizations.FirstOrDefault();

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

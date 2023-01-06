using NSubstitute;
using System.Threading;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.UpdateOrganization;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using FluentAssertions;
using TaskoMask.Services.Owners.Write.Domain.Events.Organizations;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Organizations
{
    public class UpdateOrganizationTests : TestsBaseFixture
    {

        #region Fields

        private UpdateOrganizationUseCase _updateOrganizationUseCase;

        #endregion

        #region Ctor

        public UpdateOrganizationTests()
        {
        }

        #endregion

        #region Test Methods



        [Fact]
        public async Task Organization_is_updated()
        {
            //Arrange
            var expectedOwner = Owners.FirstOrDefault();
            var expectedOrganization = OwnerObjectMother.CreateOrganization();
            expectedOwner.AddOrganization(expectedOrganization);
            var updateOrganizationRequest = new UpdateOrganizationRequest(expectedOrganization.Id, "Test New Name", "Test New Description");

            //Act
            var result = await _updateOrganizationUseCase.Handle(updateOrganizationRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Update_Success);
            result.EntityId.Should().Be(expectedOrganization.Id);

            var updatedOrganization = expectedOwner.GetOrganizationById(expectedOrganization.Id);
            updatedOrganization.Name.Value.Should().Be(updateOrganizationRequest.Name);
            updatedOrganization.Description.Value.Should().Be(updateOrganizationRequest.Description);

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<OrganizationUpdatedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<OrganizationUpdated>());
        }

        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateOrganizationUseCase = new UpdateOrganizationUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}

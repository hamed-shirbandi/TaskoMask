using FluentAssertions;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization;
using TaskoMask.Services.Owners.Write.Domain.Events.Organizations;
using TaskoMask.Services.Owners.Write.UnitTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.UnitTests.UseCases.Organizations
{
    public class AddOrganizationTests : TestsBaseFixture
    {

        #region Fields

        private AddOrganizationUseCase _addOrganizationUseCase;

        #endregion

        #region Ctor

        public AddOrganizationTests( )
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Organization_Is_Added()
        {
            //Arrange
            var expectedOwner = Owners.FirstOrDefault();
            var addOrganizationRequest = new AddOrganizationRequest(expectedOwner.Id,"Test_Name", "Test_Description");

            //Act
            var result = await _addOrganizationUseCase.Handle(addOrganizationRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Create_Success);
            result.EntityId.Should().NotBeNull();
            expectedOwner.Organizations.Should().Contain(o => o.Id == result.EntityId);
            await InMemoryBus.Received(1).PublishEvent(Arg.Any<OrganizationAddedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<OrganizationAdded>());
        }


        [Fact]
        public void Adding_Organization_Throw_Exception_When_Owner_Not_Exist()
        {
            //Arrange
            var addOrganizationRequest = new AddOrganizationRequest("Some_Owner_Id_That_Not_Exist", "Test_Name", "Test_Description");
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            //Act
            Action act = async () => await _addOrganizationUseCase.Handle(addOrganizationRequest, CancellationToken.None);

            //Assert
            act.Should().Throw<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _addOrganizationUseCase = new AddOrganizationUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}

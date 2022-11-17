using FluentAssertions;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.UpdateOwnerProfile;
using TaskoMask.Services.Owners.Write.Domain.Events.Owners;
using TaskoMask.Services.Owners.Write.UnitTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.UnitTests.UseCases.Owners
{
    public class UpdateOwnerProfileTests : TestsBaseFixture
    {

        #region Fields

        private UpdateOwnerProfileUseCase _updateOwnerProfileUseCase;

        #endregion

        #region Ctor

        public UpdateOwnerProfileTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Owner_Profile_Is_Updated()
        {
            //Arrange
            var expectedUser = Owners.FirstOrDefault();
            var updateOwnerProfileRequest = new UpdateOwnerProfileRequest(expectedUser.Id,"Test_New_DisplayName", "Test_New@email.com");

            //Act
            var result = await _updateOwnerProfileUseCase.Handle(updateOwnerProfileRequest, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedUser.Id);
            expectedUser.Email.Value.Should().Be(updateOwnerProfileRequest.Email);
            await InMemoryBus.Received(1).PublishEvent(Arg.Any<OwnerProfileUpdatedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<OwnerProfileUpdated>());
        }



        [Fact]
        public void Owner_Profile_Update_Throw_Exception_When_Owner_Not_Exist()
        {
            //Arrange
            var expectedUserId ="Some_Id_That_Not_Exist";
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);
            var updateOwnerProfileRequest = new UpdateOwnerProfileRequest(expectedUserId, "Test_New_DisplayName", "Test_New@email.com");

            //Act
            Action act = async () => await _updateOwnerProfileUseCase.Handle(updateOwnerProfileRequest, CancellationToken.None);

            //Assert
            act.Should().Throw<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateOwnerProfileUseCase = new UpdateOwnerProfileUseCase(OwnerAggregateRepository,OwnerValidatorService, MessageBus, InMemoryBus);
        }

        #endregion
    }
}

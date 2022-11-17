using FluentAssertions;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
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
        public async Task Owner_Profile_Is_Updated_Properly()
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



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateOwnerProfileUseCase = new UpdateOwnerProfileUseCase(OwnerAggregateRepository,OwnerValidatorService, MessageBus, InMemoryBus);
        }

        #endregion
    }
}

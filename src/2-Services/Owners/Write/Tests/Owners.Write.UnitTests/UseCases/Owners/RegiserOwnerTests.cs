using FluentAssertions;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;
using TaskoMask.Services.Owners.Write.Domain.Events.Owners;
using TaskoMask.Services.Owners.Write.UnitTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.UnitTests.UseCases.Owners
{
    public class RegiserOwnerTests : TestsBaseFixture
    {

        #region Fields

        private RegiserOwnerUseCase _regiserOwnerUseCase;

        #endregion

        #region Ctor

        public RegiserOwnerTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Owner_Is_Registered_Properly()
        {
            //Arrange
            var regiserOwnerRequest = new RegiserOwnerRequest("Test_DisplayName", "Test@email.com", "Test_Password");

            //Act
            var result = await _regiserOwnerUseCase.Handle(regiserOwnerRequest, CancellationToken.None);

            //Assert
            var createdUser = Owners.FirstOrDefault(u => u.Id == result.EntityId);
            createdUser.Email.Value.Should().Be(regiserOwnerRequest.Email);
            await InMemoryBus.Received(1).PublishEvent(Arg.Any<OwnerRegisteredEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<OwnerRegistered>());
        }



        [Fact]
        public void Owner_Is_Not_Registered_When_Email_Is_Duplicated()
        {
            //Arrange
            var expectedMessage = DomainMessages.Email_Already_Exist;
            var existedUser = Owners.FirstOrDefault();
            var regiserOwnerRequest = new RegiserOwnerRequest("Test_DisplayName", existedUser.Email.Value, "Test_Password");

            //Act
            Action act =async () => await _regiserOwnerUseCase.Handle(regiserOwnerRequest, CancellationToken.None);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }


        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _regiserOwnerUseCase = new RegiserOwnerUseCase(OwnerAggregateRepository, OwnerValidatorService, MessageBus, InMemoryBus);
        }

        #endregion
    }
}

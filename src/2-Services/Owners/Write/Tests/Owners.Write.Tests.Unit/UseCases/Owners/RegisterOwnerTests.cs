using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;
using TaskoMask.Services.Owners.Write.Domain.Events.Owners;
using TaskoMask.Services.Owners.Write.Domain.ValueObjects.Owners;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Owners
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
        public async Task Owner_is_registered()
        {
            //Arrange
            var regiserOwnerRequest = new RegiserOwnerRequest("Test_DisplayName", "Test@email.com", "Test_Password");

            //Act
            var result = await _regiserOwnerUseCase.Handle(regiserOwnerRequest, CancellationToken.None);

            //Assert
            var registeredOwner = Owners.FirstOrDefault(u => u.Id == result.EntityId);
            registeredOwner.Email.Value.Should().Be(regiserOwnerRequest.Email);
            await InMemoryBus.Received(1).PublishEvent(Arg.Any<OwnerRegisteredEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<OwnerRegistered>());
        }



        [Fact]
        public async Task Owner_is_not_registered_if_email_is_not_unique()
        {
            //Arrange
            var expectedMessage = DomainMessages.Email_Already_Exist;
            var existedOwner = Owners.FirstOrDefault();
            var regiserOwnerRequest = new RegiserOwnerRequest("Test_DisplayName", existedOwner.Email.Value, "Test_Password");

            //Act
            System.Func<Task> act =async () => await _regiserOwnerUseCase.Handle(regiserOwnerRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [InlineData("H")]
        [InlineData("Ha")]
        [Theory]
        public async Task Owner_is_not_registered_if_displayName_lenght_is_less_than_min(string displayName)
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMetadata.Length_Error, nameof(OwnerDisplayName), DomainConstValues.Owner_DisplayName_Min_Length, DomainConstValues.Owner_DisplayName_Max_Length);
            var regiserOwnerRequest = new RegiserOwnerRequest(displayName, "Test@email.com", "Test_Password");

            //Act
            System.Func<Task> act = async () => await _regiserOwnerUseCase.Handle(regiserOwnerRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [InlineData("Hamed Shirbandi just came back from the street after looking for some freedom in Iran! #MahsaAmini")]
        [InlineData("Vihan Shirbandi was waiting to see his father ( I am his father :D )")]
        [Theory]
        public async Task Owner_is_not_registered_if_displayName_lenght_is_more_than_max(string displayName)
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMetadata.Length_Error, nameof(OwnerDisplayName), DomainConstValues.Owner_DisplayName_Min_Length, DomainConstValues.Owner_DisplayName_Max_Length);
            var regiserOwnerRequest = new RegiserOwnerRequest(displayName, "Test@email.com", "Test_Password");

            //Act
            System.Func<Task> act = async () => await _regiserOwnerUseCase.Handle(regiserOwnerRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [InlineData("Hamed@taskomask")]
        [InlineData("Ha.Taskomask.ir")]
        [InlineData("Ha.Taskomask")]
        [Theory]
        public async Task Owner_is_not_registered_if_email_is_not_valid(string email)
        {
            //Arrange
            var expectedMessage = DomainMessages.Invalid_Email_Address;
            var regiserOwnerRequest = new RegiserOwnerRequest("Test_DisplayName", email, "Test_Password");

            //Act
            System.Func<Task> act = async () => await _regiserOwnerUseCase.Handle(regiserOwnerRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
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

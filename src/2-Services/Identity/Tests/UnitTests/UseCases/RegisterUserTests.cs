using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Application.UseCases.RegisterUser;
using TaskoMask.Services.Identity.Domain.Events;
using TaskoMask.Services.Identity.UnitTests.Fixtures;
using TaskoMask.Services.Identity.UnitTests.Helpers;
using TaskoMask.Services.Identity.UnitTests.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.UnitTests.UseCases
{
    public class RegisterUserTests : TestsBaseFixture
    {
        #region Fields

        private RegisterUserUseCase _regiserUserUseCase;

        #endregion

        #region Ctor

        public RegisterUserTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task User_Is_Registered()
        {
            //Arrange
            var registerUserRequest = new RegisterUserRequest("test@taskomask.ir", "TestPass");

            //Act
            var result = await _regiserUserUseCase.Handle(registerUserRequest, CancellationToken.None);

            //Assert
            TestUsers.Should().HaveCount(1);
            var registeredUser = TestUsers.FirstOrDefault(u => u.Id == result.EntityId);
            registeredUser.UserName.Should().Be(registerUserRequest.Email);
            await InMemoryBus.Received(1).PublishEvent(Arg.Any<UserRegisteredEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<UserRegistered>());
        }




        [Fact]
        public async Task User_Is_Not_Registered_When_Email_Is_Duplicated()
        {
            //Arrange
            var expectedMessage = ApplicationMessages.UserName_Already_Exist;
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            await TestUserManager.CreateAsync(userBuilder.Build(), userBuilder.Password);

            var registerUserRequest = new RegisterUserRequest(userBuilder.Email, "TestPass");

            //Act
            System.Func<Task> act = async () => await _regiserUserUseCase.Handle(registerUserRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }

        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _regiserUserUseCase = new RegisterUserUseCase(TestUserManager, MessageBus, InMemoryBus, NotificationHandler);
        }

        #endregion
    }
}

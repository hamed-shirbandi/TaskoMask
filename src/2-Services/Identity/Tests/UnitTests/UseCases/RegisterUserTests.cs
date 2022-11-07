using FluentAssertions;
using NSubstitute;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Application.UseCases.RegisterUser;
using TaskoMask.Services.Identity.Domain.Events;
using TaskoMask.Services.Identity.UnitTests.Fixtures;
using TaskoMask.Services.Identity.UnitTests.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.UnitTests.UseCases
{
    public class RegisterUserTests : BaseFixture
    {

        [Fact]
        public async Task User_Is_Registered()
        {
            //Arrange

            var useCase = new RegisterUserUseCase(TestUserManager, MessageBus, InMemoryBus, NotificationHandler);
            var registerUserRequest = new RegisterUserRequest("test@taskomask.ir", "TestPass");

            //Act
            var result = await useCase.Handle(registerUserRequest, CancellationToken.None);

            //Assert
            TestUsers.Should().HaveCount(1);
            var registeredUser = TestUsers.FirstOrDefault(u => u.Id == result.EntityId);
            registeredUser.UserName.Should().Be(registerUserRequest.Email);
            await InMemoryBus.Received(1).PublishEvent(Arg.Any<UserRegisteredEvent>());
        }




        [Fact]
        public void User_Is_Not_Registered_With_Duplicated_UserName()
        {
            //Arrange
            var expectedMessage = ApplicationMessages.UserName_Already_Exist;
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var useCase = new RegisterUserUseCase(TestUserManager, MessageBus, InMemoryBus, NotificationHandler);
            var registerUserRequest = new RegisterUserRequest(userBuilder.Email, "NewPass");

            //Act
            Action act = async () => await useCase.Handle(registerUserRequest, CancellationToken.None);

            //Assert
            act.Should().Throw<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }
    }
}

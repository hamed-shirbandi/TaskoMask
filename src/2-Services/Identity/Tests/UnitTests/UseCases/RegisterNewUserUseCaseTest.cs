using FluentAssertions;
using NSubstitute;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser;
using TaskoMask.Services.Identity.Domain.Events;
using TaskoMask.Services.Identity.UnitTests.Fixtures;
using TaskoMask.Services.Identity.UnitTests.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.UnitTests.UseCases
{
    public class RegisterNewUserUseCaseTest : BaseFixture
    {

        [Fact]
        public async Task User_Is_Registered()
        {
            //Arrange

            var useCase = new RegisterNewUserUseCase(TestUserManager, InMemoryBus, NotificationHandler);
            var registerNewUserRequest = new RegisterNewUserRequest("test@taskomask.ir", "TestPass");

            //Act
            var result = await useCase.Handle(registerNewUserRequest, CancellationToken.None);

            //Assert
            TestUsers.Should().HaveCount(1);
            var registeredUser = TestUsers.FirstOrDefault(u => u.Id == result.EntityId);
            registeredUser.UserName.Should().Be(registerNewUserRequest.Email);
            await InMemoryBus.Received(1).Publish(Arg.Any<NewUserRegistered>());
        }




        [Fact]
        public async Task User_Is_Not_Registered_With_Duplicated_UserName()
        {
            //Arrange
            var expectedMessage = ApplicationMessages.UserName_Already_Exist;
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var useCase = new RegisterNewUserUseCase(TestUserManager, InMemoryBus, NotificationHandler);
            var registerNewUserRequest = new RegisterNewUserRequest(userBuilder.Email, "NewPass");

            //Act
            Action act = async () => await useCase.Handle(registerNewUserRequest, CancellationToken.None);

            //Assert
            act.Should().Throw<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }
    }
}

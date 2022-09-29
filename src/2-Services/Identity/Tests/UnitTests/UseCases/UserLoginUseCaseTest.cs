using FluentAssertions;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;
using TaskoMask.Services.Identity.UnitTests.Fixtures;
using TaskoMask.Services.Identity.UnitTests.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.UnitTests.UseCases
{
    public class UserLoginUseCaseTest : BaseFixture
    {

        [Fact]
        public async Task User_Is_Logged_In()
        {
            //Arrange
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var useCase = new UserLoginUseCase(TestUserManager, TestSignInManager);
            var userLoginRequest = new UserLoginRequest
            {
                UserName = userBuilder.UserName,
                Password = userBuilder.Password,
            };

            //Act
            var result = await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            TestUserLogins.Should().HaveCount(1);
        }


        [Fact]
        public async Task User_Is_Not_Logged_In_With_Wrong_Password()
        {
            //Arrange
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var useCase = new UserLoginUseCase(TestUserManager, TestSignInManager);
            var userLoginRequest = new UserLoginRequest
            {
                UserName = userBuilder.UserName,
                Password = "wrongpass",
            };

            //Act
            var result = await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be(ApplicationMessages.InvalidCredentialsErrorMessage);
        }

    }
}

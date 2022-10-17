using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
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

            var useCase = new UserLoginUseCase(TestUserManager, TestSignInManager, Mapper);
            var userLoginRequest = new UserLoginRequest(userBuilder.UserName, userBuilder.Password,true);

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
            var expectedMessage = ApplicationMessages.Invalid_Credentials;

            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var useCase = new UserLoginUseCase(TestUserManager, TestSignInManager, Mapper);
            var userLoginRequest = new UserLoginRequest(userBuilder.UserName, "wrongpass", true);

            //Act
            Action act = async () => await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            act.Should().Throw<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }


        [Fact]
        public async Task Deactive_User_Is_Not_Logged_In()
        {
            //Arrange
            var expectedMessage = ApplicationMessages.Deactive_User_Can_Not_Login;

            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(false);

            TestUsers.Add(userBuilder.Build());

            var useCase = new UserLoginUseCase(TestUserManager, TestSignInManager, Mapper);
            var userLoginRequest = new UserLoginRequest(userBuilder.UserName, userBuilder.Password, true);

            //Act
            Action act = async () => await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            act.Should().Throw<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));

        }

    }
}

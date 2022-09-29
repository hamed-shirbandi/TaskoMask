using FluentAssertions;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;
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

            var useCase = new RegisterNewUserUseCase(TestUserManager);
            var userLoginRequest = new RegisterNewUserRequest
            {
                Email = "test@taskomask.ir",
                Password = "TestPass",
            };

            //Act
            var result = await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            TestUsers.Should().HaveCount(1);
            TestUsers.FirstOrDefault().UserName.Should().Be(userLoginRequest.Email);
        }


        [Fact]
        public async Task User_Is_Not_Registered_With_Duplicated_UserName()
        {
            //Arrange
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var useCase = new RegisterNewUserUseCase(TestUserManager);
            var userLoginRequest = new RegisterNewUserRequest
            {
                Email = userBuilder.Email,
                Password = "NewPass",
            };

            //Act
            var result = await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeFalse();
            result.Message.Should().Be(ApplicationMessages.UserName_Already_Exist);

        }



    }
}

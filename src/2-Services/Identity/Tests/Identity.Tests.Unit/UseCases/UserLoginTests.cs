using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;
using TaskoMask.Services.Identity.Tests.Unit.Fixtures;
using TaskoMask.Services.Identity.Tests.Unit.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.Tests.Unit.UseCases
{
    public class UserLoginTests : TestsBaseFixture
    {

        #region Fields

        private UserLoginUseCase _userLoginUseCase;

        #endregion

        #region Ctor

        public UserLoginTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task User_is_logged_in()
        {
            //Arrange
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var userLoginRequest = new UserLoginRequest(userBuilder.UserName, userBuilder.Password, true);

            //Act
            var result = await _userLoginUseCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
            TestUserLogins.Should().HaveCount(1);
        }


        [Fact]
        public async Task User_is_not_logged_in_with_wrong_password()
        {
            //Arrange
            var expectedMessage = ApplicationMessages.Invalid_Credentials;

            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            TestUsers.Add(userBuilder.Build());

            var userLoginRequest = new UserLoginRequest(userBuilder.UserName, "wrongpass", true);

            //Act
            System.Func<Task> act = async () => await _userLoginUseCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }


        [Fact]
        public async Task Deactive_user_is_not_logged_in()
        {
            //Arrange
            var expectedMessage = ApplicationMessages.Deactive_User_Can_Not_Login;

            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(false);

            TestUsers.Add(userBuilder.Build());

            var userLoginRequest = new UserLoginRequest(userBuilder.UserName, userBuilder.Password, true);

            //Act
            System.Func<Task> act = async () => await _userLoginUseCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));

        }

        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _userLoginUseCase = new UserLoginUseCase(TestUserManager, TestSignInManager, Mapper);
        }

        #endregion



    }
}

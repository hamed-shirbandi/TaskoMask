using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using TaskoMask.BuildingBlocks.Test;
using TaskoMask.Services.Identity.Application.UseCases.UserLogin;
using TaskoMask.Services.Identity.Domain.Entities;
using TaskoMask.Services.Identity.UnitTests.TestData;
using Xunit;

namespace TaskoMask.Services.Identity.UnitTests.UseCases
{
    public class UserLoginUseCaseTest : UnitTestsBase
    {
        #region Fields

        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private List<User> _users;

        #endregion

        #region Test Methods


        [Fact]
        public async Task User_Is_Logged_In()
        {
            //Arrange
            var userBuilder = UserBuilder.Init()
                .WithUserName("test@taskomask.ir")
                .WithEmail("test@taskomask.ir")
                .WithPassword("TestPass")
                .WithIsActive(true);

            _users.Add(userBuilder.Build());

            var useCase = new UserLoginUseCase(_userManager, _signInManager);
            var userLoginRequest = new UserLoginRequest
            {
                UserName = userBuilder.UserName,
                Password = userBuilder.Password,
            };

            //Act
            var result = await useCase.Handle(userLoginRequest, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }


        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void FixtureSetup()
        {
            var store = Substitute.For<IUserStore<User>>;
            _userManager = Substitute.For<ApplicationUserManager>();
            _signInManager = Substitute.For<ApplicationSignInManager>(_userManager);
            _users = new List<User>();

            _signInManager.PasswordSignInAsync(userName: Arg.Any<string>(), password: Arg.Any<string>(), isPersistent: Arg.Any<bool>(), lockoutOnFailure: Arg.Any<bool>()).Returns( args =>
            {
                 var userExist = _users.Any(u => u.UserName == (string)args[0] && u.PasswordHash == (string)args[1]);

                return (SignInResult)(true ? new FakeSignInResult(true) : new FakeSignInResult(false));
            });

        }



        #endregion

    }

    public class FakeSignInResult : SignInResult
    {
        public FakeSignInResult(bool succeeded = false)
        {
            Succeeded = succeeded;
        }
    }


    public class ApplicationUserManager : UserManager<User>
    {

        public ApplicationUserManager() : base(Substitute.For<IUserStore<User>>(), null, null, null, null, null, null, null, null)
        {
            // configuration-blah-blah
        }
    }


    public class ApplicationSignInManager : SignInManager<User>
    {

        public ApplicationSignInManager(ApplicationUserManager applicationUserManager) : base(applicationUserManager, Substitute.For<IHttpContextAccessor>(), Substitute.For<IUserClaimsPrincipalFactory<User>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<ILogger<SignInManager<User>>>(), Substitute.For<IAuthenticationSchemeProvider>(), Substitute.For<IUserConfirmation<User>>())
        {
            // configuration-blah-blah
        }
    }
}

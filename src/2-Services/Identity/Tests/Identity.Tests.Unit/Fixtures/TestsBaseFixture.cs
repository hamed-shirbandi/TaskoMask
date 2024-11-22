using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Identity.Api.Domain.Entities;
using TaskoMask.Services.Identity.Tests.Unit.Helpers;

namespace TaskoMask.Services.Identity.Tests.Unit.Fixtures;

/// <summary>
///
/// </summary>
public abstract class TestsBaseFixture : UnitTestsBase
{
    public TestUserManager TestUserManager;
    public TestSignInManager TestSignInManager;
    public INotificationService NotificationHandler;
    public IEventPublisher MessageBus;
    public IRequestDispatcher InMemoryBus;
    public IMapper Mapper;

    public List<User> TestUsers;
    public List<UserLogin> TestUserLogins;

    ///// <summary>
    /////
    ///// </summary>
    protected override void FixtureSetup()
    {
        CommonFixtureSetup();

        TestClassFixtureSetup();
    }

    /// <summary>
    ///
    /// </summary>
    private void CommonFixtureSetup()
    {
        TestUserManager = Substitute.For<TestUserManager>();
        TestSignInManager = Substitute.For<TestSignInManager>(TestUserManager);
        TestUsers = new List<User>();
        TestUserLogins = new List<UserLogin>();
        NotificationHandler = Substitute.For<INotificationService>();
        MessageBus = Substitute.For<IEventPublisher>();
        InMemoryBus = Substitute.For<IRequestDispatcher>();
        Mapper = Substitute.For<IMapper>();

        TestSignInManager
            .PasswordSignInAsync(
                userName: Arg.Any<string>(),
                password: Arg.Any<string>(),
                isPersistent: Arg.Any<bool>(),
                lockoutOnFailure: Arg.Any<bool>()
            )
            .Returns(args =>
            {
                var userExist = TestUsers.Any(u => u.UserName == (string)args[0] && u.PasswordHash == (string)args[1]);

                return userExist ? new TestSignInResult(true) : new TestSignInResult(false);
            });

        TestUserManager
            .FindByNameAsync(userName: Arg.Any<string>())
            .Returns(args =>
            {
                return TestUsers.FirstOrDefault(u => u.UserName == (string)args[0]);
            });

        TestUserManager
            .CreateAsync(user: Arg.Any<User>(), password: Arg.Any<string>())
            .Returns(args =>
            {
                TestUsers.Add((User)args[0]);
                return new TestIdentityResult(true);
            });

        TestUserManager
            .AddLoginAsync(user: Arg.Any<User>(), login: Arg.Any<UserLoginInfo>())
            .Returns(args =>
            {
                var user = (User)args[0];
                var UserLoginInfo = (UserLoginInfo)args[1];
                var userlogin = new UserLogin
                {
                    UserId = user.Id,
                    LoginProvider = UserLoginInfo.LoginProvider,
                    ProviderDisplayName = UserLoginInfo.ProviderDisplayName,
                    ProviderKey = UserLoginInfo.ProviderKey,
                };
                TestUserLogins.Add(userlogin);
                return new TestIdentityResult(true);
            });
    }

    /// <summary>
    /// Each test class should setup its own fixture
    /// </summary>
    protected abstract void TestClassFixtureSetup();
}

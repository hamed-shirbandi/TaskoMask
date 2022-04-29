using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using Xunit;

namespace TaskoMask.Application.Tests.Integration.Workspace
{
    public class UserServiceIntegrationTests : TestsBase
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctor

        //Run before each test method
        public UserServiceIntegrationTests()
        {
            _userService = GetRequiredService<IUserService>();
        }

        #endregion

        #region Test Mthods



        [Fact]
        public async Task User_Is_Created_Properly()
        {
            //Arrange

            //Act
            var result = await _userService.CreateAsync("TestUserName", "TestPass");

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();
        }



        [Fact]
        public async Task User_Is_Updated_Properly()
        {
            //Arrange
            var createdUserResult = await _userService.CreateAsync("TestUserName", "TestPass");
            var createdUserId = createdUserResult.Value.EntityId;
            var expectedUserName = "NewUserName";

            //Act
            var result = await _userService.UpdateUserNameAsync(createdUserId, expectedUserName);
            var updatedUserResult = await _userService.GetByIdAsync(createdUserId);

            //Assert
            result.IsSuccess.Should().BeTrue();
            updatedUserResult.Value.UserName.Should().Be(expectedUserName);

        }


        #endregion

    }
}

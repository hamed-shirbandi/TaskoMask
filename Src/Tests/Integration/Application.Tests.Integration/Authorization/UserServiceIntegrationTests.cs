using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Authorization
{
    public class UserServiceIntegrationTests : IClassFixture<UserClassFixture>
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly UserClassFixture _fixture;

        #endregion

        #region Ctor

        public UserServiceIntegrationTests(UserClassFixture fixture)
        {
            _fixture = fixture;
            _userService = _fixture.GetRequiredService<IUserService>();
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
        public async Task User_Is_Fetched_Properly()
        {
            //Arrange
            var createdUserId = "createdUserId";

            //Act
            var updatedUserResult = await _userService.GetByIdAsync(createdUserId);

            //Assert
            updatedUserResult.Value.Id.Should().Be(createdUserId);
        }



        [Fact]
        public async Task User_Is_Updated_Properly()
        {
            //Arrange
            var createdUserId = "createdUserId";
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

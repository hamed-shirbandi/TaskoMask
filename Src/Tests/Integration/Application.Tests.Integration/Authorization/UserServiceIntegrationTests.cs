using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using Xunit;
using Xunit.Priority;

namespace TaskoMask.Application.Tests.Integration.Workspace
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class UserServiceIntegrationTests : IClassFixture<TestsBaseFixture>
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly TestsBaseFixture _fixture;

        #endregion

        #region Ctor

        public UserServiceIntegrationTests(TestsBaseFixture fixture)
        {
            _fixture = fixture;
            _userService = _fixture.GetRequiredService<IUserService>();
        }

        #endregion

        #region Test Mthods



        [Fact, Priority(0)]
        public async Task User_Is_Created_Properly()
        {
            //Arrange


            //Act
            var result = await _userService.CreateAsync("TestUserName", "TestPass");

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();

            _fixture.SaveToMemeory(MagicKey.User.Created_User_Id, result.Value.EntityId);
        }



        [Fact, Priority(1)]
        public async Task User_Is_Fetched_Properly()
        {
            //Arrange
            var createdUserId = _fixture.GetFromMemeory(MagicKey.User.Created_User_Id);

            //Act
            var updatedUserResult = await _userService.GetByIdAsync(createdUserId);

            //Assert
            updatedUserResult.Value.Id.Should().Be(createdUserId);
        }



        [Fact, Priority(2)]
        public async Task User_Is_Updated_Properly()
        {
            //Arrange
            var createdUserId = _fixture.GetFromMemeory(MagicKey.User.Created_User_Id);
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

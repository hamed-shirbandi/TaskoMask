using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Authorization
{
    public class UserServiceIntegrationTests : IClassFixture<UserClassFixture>
    {
        #region Fields

        private readonly UserClassFixture _fixture;

        #endregion

        #region Ctor

        public UserServiceIntegrationTests(UserClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods



        [Fact]
        public async Task User_Is_Created()
        {
            //Arrange
            var userName = "TestUserName";
            var password = "TestPass";

            //Act
            var result = await _fixture.UserService.CreateAsync(userName, password);
   
            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();
        }



        [Fact]
        public async Task User_Is_Fetched()
        {
            //Arrange
            var expectedUser =await _fixture.GetSampleUserAsync();

            //Act
            var result = await _fixture.UserService.GetByIdAsync(expectedUser.Id);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.UserName.Should().Be(expectedUser.UserName);
        }



        [Fact]
        public async Task User_Is_Updated()
        {
            //Arrange
            var userToUpdate = await _fixture.GetSampleUserAsync();
            var expectedUserName = "NewUserName";

            //Act
            var result = await _fixture.UserService.UpdateUserNameAsync(userToUpdate.Id, expectedUserName);

            //Assert
            result.IsSuccess.Should().BeTrue();
            var updatedUserResult = await _fixture.UserService.GetByIdAsync(userToUpdate.Id);
            updatedUserResult.Value.UserName.Should().Be(expectedUserName);
        }


        #endregion

    }
}

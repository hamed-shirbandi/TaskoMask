using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Authorization.Users.Services;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Application.Tests.Unit.TestData;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;
using Xunit;
using TaskoMask.Services.Monolith.Application.Core.Resources;

namespace TaskoMask.Services.Monolith.Application.Tests.Unit.Authorization
{
    public class UserServiceUnitTests : TestsBase
    {
        #region Fields

        private IUserRepository _userRepository;
        private IUserService _userService;
        private List<User> _users;

        #endregion

        #region Test Methods



        [Fact]
        public async void User_Is_Created()
        {
            //Arrange
            var expectedUserName = "TestUserName";

            //Act
            var result = await _userService.CreateAsync(expectedUserName, "TestPassword",UserType.Owner);

            //Asserrt
            result.IsSuccess.Should().Be(true);
            var createdUser = _users.FirstOrDefault(u => u.Id == result.Value.EntityId);
            createdUser.UserName.Should().Be(expectedUserName);
        }





        [InlineData("NewUserName")]
        [InlineData("TestUserName")]
        [Theory]
        public async void UserName_Is_Updated_Properly(string expectedUserName)
        {
            //Arrange
            var user = _users.First();

            //Act
            var result = await _userService.UpdateUserNameAsync(user.Id, expectedUserName);

            //Asserrt
            result.IsSuccess.Should().Be(true);
            result.Value.EntityId.Should().Be(user.Id);
            user.UserName.Should().Be(expectedUserName);
        }



        [Fact]
        public async void User_Is_Not_Created_When_UserName_Is_Already_Exist()
        {
            //Arrange
            var existUserName = _users.First().UserName;

            //Act
            var result = await _userService.CreateAsync(existUserName, "TestPassword", UserType.Owner);

            //Asserrt
            result.IsSuccess.Should().Be(false);
            result.Message.Should().Be(ApplicationMessages.User_Email_Already_Exist);
        }



        [InlineData(true)]
        [InlineData(false)]
        [Theory]
        public async void User_Activity_Permission_Is_Changed(bool isActive)
        {
            //Arrange
            var user = _users.First();
            var expectedUserIsActiveValue = isActive;

            //Act
            var result = await _userService.SetIsActiveAsync(user.Id, expectedUserIsActiveValue);

            //Asserrt
            result.IsSuccess.Should().Be(true);
            result.Value.EntityId.Should().Be(user.Id);
            user.IsActive.Should().Be(expectedUserIsActiveValue);
        }



        [Fact]
        public async void User_Can_Login_When_Credential_Is_Valid()
        {
            //Arrange
            var expectedUserName = "TestUserName";
            var expectedUserPassword = "TestPassword";
            //create user
            await _userService.CreateAsync(expectedUserName, expectedUserPassword, UserType.Owner);

            //Act
            var result = await _userService.IsValidCredentialAsync(expectedUserName, expectedUserPassword);

            //Asserrt
            result.IsSuccess.Should().Be(true);
            result.Value.Should().Be(true);
        }



        [Fact]
        public async void User_Can_Not_Login_When_Is_Not_Active()
        {
            //Arrange
            var expectedUserName = "TestUserName";
            var expectedUserPassword = "TestPassword";
            var expectedMessage = ApplicationMessages.User_Is_Not_Active_And_Can_Not_Login;
            //create user and set IsActive to false
            var userCreateResult = await _userService.CreateAsync(expectedUserName, expectedUserPassword, UserType.Owner);
            await _userService.SetIsActiveAsync(userCreateResult.Value.EntityId, false);

            //Act
            var result = await _userService.IsValidCredentialAsync(expectedUserName, expectedUserPassword);

            //Asserrt
            result.IsSuccess.Should().Be(false);
            result.Message.Should().Be(expectedMessage);
        }



        #endregion

        #region Private Methods



        protected override void TestClassFixtureSetup()
        {
            _users = DataGenerator.GenerateUserList();
            _userRepository = Substitute.For<IUserRepository>();
            _userRepository.GetByUserNameAsync(Arg.Is<string>(x => _users.Select(u => u.UserName).Contains(x))).Returns(args => _users.First(u => u.UserName == (string)args[0]));
            _userRepository.ExistByUserNameAsync(Arg.Is<string>(x => _users.Select(u => u.UserName).Contains(x))).Returns(args => _users.Any(u => u.UserName == (string)args[0]));
            _userRepository.GetByIdAsync(Arg.Is<string>(x => _users.Any(u => u.Id == x))).Returns(args => _users.First(u => u.Id == (string)args[0]));
            _userRepository.CreateAsync(Arg.Any<User>()).Returns(async args => _users.Add((User)args[0]));
            _userRepository.UpdateAsync(Arg.Is<User>(x => _users.Any(u => u.Id == x.Id))).Returns(async args =>
            {
                var existUser = _users.FirstOrDefault(u => u.Id == ((User)args[0]).Id);
                if (existUser != null)
                {
                    _users.Remove(existUser);
                    _users.Add(((User)args[0]));
                }
            });

            _userService = new UserService(_inMemoryBus, _iMapper, _domainNotificationHandler, _userRepository);
        }





        #endregion

    }
}
